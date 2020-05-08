using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Safe.PL.Controls
{
    public enum PinEntryControlState
    {
        ENTRY_IN_PROGRESS,
        TOO_MANY_TRIES,
        PIN_AUTH_SUCCESS,
        FINGERPRINT_AUTH_SUCCESS
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinEntryControl : StackLayout, INotifyPropertyChanged
    {
        //public static readonly BindableProperty PinLengthProperty =
        //    BindableProperty.Create(nameof(PinLength), typeof(UInt32), typeof(PinEntryControl), (UInt32)4);
        
        public static readonly BindableProperty AllowedNumberOfTriesProperty =
            BindableProperty.Create(nameof(AllowedNumberOfTries), typeof(UInt32), typeof(PinEntryControl), (UInt32)3);

        public static readonly BindableProperty AllowFingerprintAuthProperty =
            BindableProperty.Create(nameof(AllowFingerprintAuth), typeof(Boolean), typeof(PinEntryControl), true);

        public static readonly BindableProperty CorrectPinProperty =
            BindableProperty.Create(nameof(CorrectPin), typeof(String), typeof(PinEntryControl));

        public delegate void NotifyMajorPinEventHandler(PinEntryControlState state);

        public event NotifyMajorPinEventHandler NotifyMajorPinEvent;

        private List<Frame> _PinCharHolders;

        private Stack<Char> _EnteredPinSequence;

        private UInt32 _NumberOfTriesDone;

        private PinEntryControlState _State;

        public PinEntryControlState State
        {
            get { return _State; }
        }


        public PinEntryControl()
        {
            _NumberOfTriesDone = 0;
            _State = PinEntryControlState.ENTRY_IN_PROGRESS;
            _EnteredPinSequence = new Stack<char>();
            _PinCharHolders = new List<Frame>();

            InitializeComponent();
            AddPinHoldersToUI();

            PropertyChanged += PinEntryControl_PropertyChanged;

            UpdateUIForFingerPrintAuthAvailability();
        }

        private async void UpdateUIForFingerPrintAuthAvailability()
        {
            if (AllowFingerprintAuth)
            {
                bool isFingerprintAuthAvailable = await CrossFingerprint.Current.IsAvailableAsync();
                if (isFingerprintAuthAvailable)
                {
                    fingerPrintAuthImg.IsVisible = true;
                }
            }
        }

        private void AddPinHoldersToUI()
        {
            for (int i = 0; i < PinLength; i++)
            {
                Frame pinCharHolder = new Frame()
                {
                    BorderColor = Color.Orange,
                    CornerRadius = 10,
                    BackgroundColor = Color.Transparent,
                    HeightRequest = 10,
                    WidthRequest = 10
                };
                _PinCharHolders.Add(pinCharHolder);
                pinDisplayStack.Children.Add(pinCharHolder);
            }
        }

        private void PinEntryControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "CorrectPin":
                    {
                        _PinCharHolders.Clear();
                        pinDisplayStack.Children.Clear();
                        AddPinHoldersToUI();
                    }
                    break;
            }
        }

        public UInt32 PinLength
        {
            get {
                if(CorrectPin != null)
                {
                    return (UInt32)CorrectPin.Length;
                }
                else
                {
                    return 0;
                }
            }
            //set { base.SetValue(PinLengthProperty, value); }
        }

        public UInt32 AllowedNumberOfTries
        {
            get { return (UInt32)base.GetValue(AllowedNumberOfTriesProperty); }
            set { base.SetValue(AllowedNumberOfTriesProperty, value); }
        }

        public Boolean AllowFingerprintAuth
        {
            get { return (Boolean)base.GetValue(AllowFingerprintAuthProperty); }
            set { base.SetValue(AllowFingerprintAuthProperty, value); }
        }

        public String CorrectPin
        {
            get { return (String)base.GetValue(CorrectPinProperty); }
            set { base.SetValue(CorrectPinProperty, value); }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CustomButton button = sender as CustomButton;

            // Accept the new character and update UI
            if(_EnteredPinSequence.Count < PinLength)
            {
                if (button != null)
                {
                    _EnteredPinSequence.Push(button.Text.ToCharArray()[0]);
                    _PinCharHolders[_EnteredPinSequence.Count - 1].BackgroundColor = Color.Gray;
                }

            }
            
            // Validate PIN
            if(_EnteredPinSequence.Count == PinLength)
            {
                char[] enteredPin = _EnteredPinSequence.Reverse().ToArray();
                String enteredPinStr = new string(enteredPin);
                bool authResult = ValidatePin(enteredPinStr);
                if(authResult)
                {
                    NotifyMajorPinEvent?.Invoke(State);
                }
                else
                {
                    _NumberOfTriesDone++;
                    ResetAcceptedPin();
                    if(_NumberOfTriesDone >= AllowedNumberOfTries)
                    {
                        _State = PinEntryControlState.TOO_MANY_TRIES;
                        NotifyMajorPinEvent?.Invoke(State);
                    }
                }
            }


        }

        private void ResetAcceptedPin()
        {
            while (_EnteredPinSequence.Count != 0)
            {
                _PinCharHolders[_EnteredPinSequence.Count - 1].BackgroundColor = Color.Transparent;
                _EnteredPinSequence.Pop();
            }
        }

        private bool ValidatePin(string enteredPinStr)
        {
            if(String.Equals(enteredPinStr,CorrectPin))
            {
                _State = PinEntryControlState.PIN_AUTH_SUCCESS;
                return true;
            }
            else
            {
                Xamarin.Essentials.Vibration.Vibrate();
                return false;
            }
        }

        private async void FingerPrintScanner_Launch(object sender, EventArgs e)
        {
            AuthenticationRequestConfiguration authConfig = new AuthenticationRequestConfiguration("SAFE", "Access to SAFE");
            FingerprintAuthenticationResult authResult = await CrossFingerprint.Current.AuthenticateAsync(authConfig);
            if (authResult.Authenticated)
            {
                _State = PinEntryControlState.FINGERPRINT_AUTH_SUCCESS;
                NotifyMajorPinEvent?.Invoke(State);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Fail", "Auth failed", "Ok");
            }
        }

        private void Erase_Clicked(object sender, EventArgs e)
        {
            if (_EnteredPinSequence.Count != 0)
            {
                _PinCharHolders[_EnteredPinSequence.Count - 1].BackgroundColor = Color.Transparent;
                _EnteredPinSequence.Pop();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingLabelEntry : StackLayout
    {
        public static readonly BindableProperty LabelTextProperty = 
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(FloatingLabelEntry), String.Empty);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingLabelEntry), String.Empty,
                defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty LabelColorProperty =
            BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(FloatingLabelEntry), Color.Black);

        public static readonly BindableProperty EntryTextColorProperty =
            BindableProperty.Create(nameof(EntryTextColor), typeof(Color), typeof(FloatingLabelEntry), Color.Gray);

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(Boolean), typeof(FloatingLabelEntry), false);

        public static readonly BindableProperty IsMultilineProperty =
            BindableProperty.Create(nameof(IsMultiline), typeof(Boolean), typeof(FloatingLabelEntry), false);

        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(UInt32), typeof(FloatingLabelEntry), (UInt32)250);

        public string LabelText
        {
            get { return (string)base.GetValue(LabelTextProperty); }
            set { base.SetValue(LabelTextProperty, value); }
        }

        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set
            {
                base.SetValue(TextProperty, value);
            }
        }

        public Color LabelColor
        {
            get { return (Color)base.GetValue(LabelColorProperty); }
            set { base.SetValue(LabelColorProperty, value); }
        }

        public Color EntryTextColor
        {
            get { return (Color)base.GetValue(EntryTextColorProperty); }
            set { base.SetValue(EntryTextColorProperty, value); }
        }

        public Boolean IsPassword
        {
            get { return (Boolean)base.GetValue(IsPasswordProperty); }
            set { base.SetValue(IsPasswordProperty, value); }
        }

        public Boolean IsMultiline
        {
            get { return (Boolean)base.GetValue(IsMultilineProperty); }
            set { base.SetValue(IsMultilineProperty, value); }
        }

        public UInt32 MaxLength
        {
            get { return (UInt32)base.GetValue(MaxLengthProperty); }
            set { base.SetValue(MaxLengthProperty, value); }
        }

        public FloatingLabelEntry()
        {
            InitializeComponent();

            this.PropertyChanged += FloatingLabelEntry_PropertyChanged;

            entInputArea.BindingContext = this;
            lblLabelText.BindingContext = this;
            edtInputArea.BindingContext = this;
        }
        
        
        private void FloatingLabelEntry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "LabelText":
                    {
                        SetLabelValue();
                    }
                    break;
                case "Text":
                    {
                        SetLabelValue();
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }

        private void SetLabelValue()
        {
            if (Text == null || Text.Length == 0)
            {
                //Entry is empty
                lblLabelText.Text = " ";
                
            }
            else
            {
                //Entry is not empty
                lblLabelText.Text = LabelText;
            }
        }

        private void FLE_BindingContextChanged(object sender, EventArgs e)
        {
            entInputArea.BindingContext = this;
            lblLabelText.BindingContext = this;
            edtInputArea.BindingContext = this;
        }
    }
}
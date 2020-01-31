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
            BindableProperty.Create("LabelText", typeof(string), typeof(FloatingLabelEntry), String.Empty);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(FloatingLabelEntry), String.Empty,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: TextPropertyChanged);

        public static readonly BindableProperty LabelColorProperty =
            BindableProperty.Create("LabelColor", typeof(Color), typeof(FloatingLabelEntry), Color.Blue);

        public static readonly BindableProperty EntryTextColorProperty =
            BindableProperty.Create("EntryTextColor", typeof(Color), typeof(FloatingLabelEntry), Color.Black);

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create("IsPassword", typeof(Boolean), typeof(FloatingLabelEntry), false);

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

        private void InitializeDefaults()
        {
            IsPassword = false;
            LabelText = "Label-Here";
            Text = "Entry-Here";
            LabelColor = Color.Navy;
            EntryTextColor = Color.CornflowerBlue;
        }

        public FloatingLabelEntry()
        {
            InitializeDefaults();

            this.PropertyChanged += FloatingLabelEntry_PropertyChanged;

            InitializeComponent();
            
            this.BindingContext = this;
        }
        
        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            FloatingLabelEntry control = bindable as FloatingLabelEntry;
            if (control != null && control.entInputArea != null)
            {
                //control.entInputArea.Text = newValue.ToString();
                
            }

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
            if (Text.Length != 0)
            {
                //Entry is not empty
                lblLabelText.Text = LabelText;
            }
            else
            {
                //Entry is empty
                lblLabelText.Text = " ";
            }
        }

        private void FLE_BindingContextChanged(object sender, EventArgs e)
        {

        }
    }
}
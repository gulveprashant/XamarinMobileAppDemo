using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safe.PL.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingLabelEntry : ContentView
    {
        public static readonly BindableProperty LabelTextProperty = 
            BindableProperty.Create("LabelText", typeof(string), typeof(FloatingLabelEntry), String.Empty);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(FloatingLabelEntry), String.Empty);

        public static readonly BindableProperty LabelColorProperty =
            BindableProperty.Create("LabelColor", typeof(Color), typeof(FloatingLabelEntry), Color.Blue);

        public static readonly BindableProperty EntryTextColorProperty =
            BindableProperty.Create("EntryTextColor", typeof(Color), typeof(FloatingLabelEntry), Color.Black);

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create("IsPassword", typeof(Boolean), typeof(FloatingLabelEntry), false);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Color LabelColor
        {
            get { return (Color)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }

        public Color EntryTextColor
        {
            get { return (Color)GetValue(EntryTextColorProperty); }
            set { SetValue(EntryTextColorProperty, value); }
        }

        public Boolean IsPassword
        {
            get { return (Boolean)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public FloatingLabelEntry()
        {
            InitializeComponent();
            this.PropertyChanged += FloatingLabelEntry_PropertyChanged;

            this.BindingContext = this;

        }

        private void FloatingLabelEntry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "LabelText":
                case "Text":
                    {
                        if(Text.Length != 0)
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
                    break;
                default:
                    {

                    }
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGB_View : ContentPage
    {
        Slider sldre, sldgree, sldblu;
        Frame fr;
        Label tere, tegree, teblu;
        int reint = 0;
        int greeint = 0;
        int bluint = 0;

        public RGB_View()
        {
            tere = new Label
            {
                Text = "R: " + reint,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                TextColor = Color.Black,
            };

            tegree = new Label
            {
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                TextColor = Color.Black,
            };

            teblu = new Label
            {
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                TextColor = Color.Black,
            };
            fr = new Frame
            {
                BorderColor = Color.FromRgb(0, 0, 0),
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            sldre = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
                Margin = 20
            };
            sldre.ValueChanged += Sldre_ValueChanged;
            sldgree = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
                Margin = 20
            };
            sldgree.ValueChanged += Sldgree_ValueChanged;
            sldblu = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
                Margin = 20
            }; 
            sldblu.ValueChanged += Sldblu_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { fr, sldre, sldgree, sldblu }
            };
            Content = st;
            
        }

        private void Sldblu_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            fr.BackgroundColor = Color.FromRgb((int)sldre.Value, (int)sldgree.Value, (int)sldblu.Value);
        }

        private void Sldgree_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            fr.BackgroundColor = Color.FromRgb((int)sldre.Value, (int)sldgree.Value, (int)sldblu.Value);
        }

        private void Sldre_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            fr.BackgroundColor = Color.FromRgb((int)sldre.Value, (int)sldgree.Value, (int)sldblu.Value);
        }
    }
}

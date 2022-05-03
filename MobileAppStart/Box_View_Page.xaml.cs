using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MobileAppStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Box_View_Page : ContentPage
    {

        BoxView box;
        Label lb;
        Button btn;
        int i = 0;
        int l = 0;
        public Box_View_Page()
        {
            int r = 0, g = 0, b = 0;

            box = new BoxView
            {

                CornerRadius = 200,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Red
            };

            lb = new Label
            {
                Text = "Punkti: " + i.ToString(),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };

            btn = new Button
            {
                Text = "Punkti 100 = 2x click",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Tomato,
                TextColor = Color.Black

            };

            btn.Clicked += Btn_Clicked;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout
            {
                Children = {
                    lb,
                    btn,
                    box
                }
            };
            Content = st;
            st.BackgroundColor = Color.PeachPuff;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if (i >= 100)
            {
                i = i - 100;
                l = 1;
                lb.Text = "Punkti: " + i.ToString();
                btn.IsVisible = false;
            }
            else { }
        }

        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            /*rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));*/
            if (l != 1)
            {
                var duration = TimeSpan.FromSeconds(0.15);
                Vibration.Vibrate(duration);
                i++;
                lb.Text = "Punkti: " + i.ToString();
            }
            else
            {
                i += 2;
                lb.Text = "Punkti: " + i.ToString();
                var duration = TimeSpan.FromSeconds(0.15);
                Vibration.Vibrate(duration);
            }

        }
    }
}
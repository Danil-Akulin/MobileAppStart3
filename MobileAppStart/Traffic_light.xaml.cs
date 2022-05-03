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
    public partial class Traffic_light : ContentPage
    {
        Button btn,btn2;
        Label lbl;
        Frame fr1,fr2,fr3;
        static bool help = true;
        Frame[] fps;
        string[] names = { "Red", "Yellow", "Green" };
        public Traffic_light()
        {
            TapGestureRecognizer tap1 = new TapGestureRecognizer();
            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            TapGestureRecognizer tap3 = new TapGestureRecognizer();
            TapGestureRecognizer[] taps = new TapGestureRecognizer[3] { tap1, tap2, tap3 };
            tap1.Tapped += Tap1_Tapped;
            tap2.Tapped += Tap2_Tapped;
            tap3.Tapped += Tap3_Tapped;
            fps = new Frame[3];
            for (int i = 0; i < fps.Length; i++)
            {
                lbl = new Label
                {
                    Text = names[i],
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalTextAlignment = TextAlignment.Center,
                };
                fps[i] = new Frame
                {
                    Content = lbl,
                    BackgroundColor = Color.Black,
                    CornerRadius = 360,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };
                fps[i].GestureRecognizers.Add(taps[i]);
            }
            btn = new Button
            {
                Text = "On"
            };
            btn.Clicked += Btn_Clicked;
            btn2 = new Button
            {
                Text = "Off",
                HorizontalOptions = LayoutOptions.End
            };
            btn2.Clicked += Btn2_Clicked;
            FlexLayout fl = new FlexLayout
            {
                Children = { btn, btn2 },
                JustifyContent = FlexJustify.SpaceEvenly
            };
            Content = new StackLayout { Children = { fps[0], fps[1], fps[2], fl } };
        }


        private void Tap3_Tapped(object sender, EventArgs e)
        {
            Frame f = (Frame)sender;
            Label l = f.Content as Label;
            if (l.Text == "Go")
            {
                l.Text = "Green";
            }
            else
            {
                l.Text = "Go";
            }
        }

        private void Tap2_Tapped(object sender, EventArgs e)
        {
            Frame f = (Frame)sender;
            Label l = f.Content as Label;
            if (l.Text == "Wait")
            {
                l.Text = "Yellow";
            }
            else
            {
                l.Text = "Wait";
            }
        }

        private void Tap1_Tapped(object sender, EventArgs e)
        {
            Frame f = (Frame)sender;
            Label l = f.Content as Label;
            if (l.Text == "Stop")
            {
                l.Text = "Red";
            }
            else
            {
                l.Text = "Stop";
            }
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            help = false;
            fps[0].BackgroundColor = Color.Black;
            fps[1].BackgroundColor = Color.Black;
            fps[2].BackgroundColor = Color.Black;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            btn.BackgroundColor = Color.DarkGray;
            btn2.BackgroundColor = Color.DarkGray;
            help = true;
            do
            {
                fps[0].BackgroundColor = Color.Red;
                fps[1].BackgroundColor = Color.LightYellow;
                fps[2].BackgroundColor = Color.DarkGreen;
                await Task.Delay(3000);
                fps[0].BackgroundColor = Color.DarkRed;
                fps[1].BackgroundColor = Color.Yellow;
                fps[2].BackgroundColor = Color.DarkGreen;
                await Task.Delay(1000);
                fps[0].BackgroundColor = Color.DarkRed;
                fps[1].BackgroundColor = Color.LightYellow;
                fps[2].BackgroundColor = Color.Green;
                await Task.Delay(3000);
                fps[0].BackgroundColor = Color.DarkRed;
                fps[1].BackgroundColor = Color.Yellow;
                fps[2].BackgroundColor = Color.DarkGreen;
                await Task.Delay(1000);
            } while (help);
            btn.BackgroundColor = Color.White;
            btn2.BackgroundColor = Color.White;

        }



    }
}
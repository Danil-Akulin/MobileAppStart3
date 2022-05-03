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
    public partial class Svetofor : ContentPage
    {
        Button vkl;
        Button vekl;
        Label redpunane, yellokollane, greeroheline;
        Frame red;
        Frame yellow;
        Frame green;
        int nazata = 0;
        public Svetofor()
        {
            vkl = new Button
            {
                Text = "Sisse",
                BackgroundColor = Color.Green,
                TextColor = Color.Black
            };
            vkl.Clicked += Vkl_Clicked;
            vekl = new Button
            {
                Text = "Välja",
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.Red,
                TextColor = Color.Black
            };
            vekl.Clicked += Vekl_Clicked;

            redpunane = new Label()
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            yellokollane = new Label()
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            greeroheline = new Label()
            {
                
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };



            red = new Frame
            {
                Content = redpunane,
                BackgroundColor = Color.Gray,
                HeightRequest = 200,
                CornerRadius = 100,
                Margin = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            yellow = new Frame
            {
                Content = yellokollane,
                BackgroundColor = Color.Gray,
                HeightRequest = 200,
                CornerRadius = 100,
                Margin = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            green = new Frame
            {
                Content = greeroheline,
                BackgroundColor = Color.Gray,
                HeightRequest = 200,
                CornerRadius = 100,
                Margin = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };


            //--------------------------------------------------

            FlexLayout knopki = new FlexLayout
            {
                Children = { vkl, vekl },
                JustifyContent = FlexJustify.SpaceEvenly
            };
            StackLayout st = new StackLayout
            {
                Children = { red, yellow, green, knopki }
            };

            //------------Кликать на box---------------
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            red.GestureRecognizers.Add(tap);
            yellow.GestureRecognizers.Add(tap);
            green.GestureRecognizers.Add(tap);
            //---------------------------
            Content = st;
            st.BackgroundColor = Color.PeachPuff;

        }

        private async void Vekl_Clicked(object sender, EventArgs e)
        {

            nazata = 1;

                red.BackgroundColor = Color.Gray;
                red.Opacity = 1;
                yellow.BackgroundColor = Color.Gray;
                yellow.Opacity = 1;
                green.BackgroundColor = Color.Gray;
                green.Opacity = 1;
                redpunane.Text = "";
                yellokollane.Text = "";
                greeroheline.Text = "";

        }

        private async void Vkl_Clicked(object sender, EventArgs e)
        {
            nazata = 0;
            if (nazata == 1)
            {
                
            }
            else
            {
                redpunane.Text = "Stop";
                yellokollane.Text = "Ootama";
                greeroheline.Text = "Minna";
                while (nazata != 1)
                {
                    if (nazata == 0)
                    {
                        red.BackgroundColor = Color.Red;
                        red.Opacity = 1;
                        yellow.BackgroundColor = Color.Yellow;
                        yellow.Opacity = .2;
                        green.BackgroundColor = Color.Green;
                        green.Opacity = .2;
                        await Task.Delay(3000);
                    }
                    if (nazata == 0)
                    {
                        red.BackgroundColor = Color.Red;
                        red.Opacity = .2;
                        yellow.BackgroundColor = Color.Yellow;
                        yellow.Opacity = 1;
                        green.BackgroundColor = Color.Green;
                        green.Opacity = .2;
                        await Task.Delay(1000);
                    }
                    if (nazata == 0)
                    {
                        red.BackgroundColor = Color.Red;
                        red.Opacity = .2;
                        yellow.BackgroundColor = Color.Yellow;
                        yellow.Opacity = .2;
                        green.BackgroundColor = Color.Green;
                        green.Opacity = 1;
                        await Task.Delay(3000);
                    }
                    if (nazata == 0)
                    {
                        red.BackgroundColor = Color.Red;
                        red.Opacity = .2;
                        yellow.BackgroundColor = Color.Yellow;
                        yellow.Opacity = 1;
                        green.BackgroundColor = Color.Green;
                        green.Opacity = .2;
                        await Task.Delay(1000);
                    }
                }


            }

        }
        int i = 0;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (nazata == 0)
            {
                if (i == 0)
                {
                    redpunane.Text = "Punane";
                    yellokollane.Text = "Kollane";
                    greeroheline.Text = "Roheline";
                    i++;
                }
                else if (i == 1)
                {
                    
                    redpunane.Text = "Stop";
                    yellokollane.Text = "Ootama";
                    greeroheline.Text = "Minna";
                    i = 0;
                }
            }
            else
            {
                redpunane.Text = "";
                yellokollane.Text = "";
                greeroheline.Text = "";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class trips : ContentPage
    {
        public bool esimene;
        int tulemus = 2;
        int[,] Tulemused = new int[3, 3] { { 5, 5, 5 }, { 5, 5, 5 }, { 5, 5, 5 } };
        Grid g, g2;
        Button uus_mang, button;
        Image img;
        bool x = false;
        List<Image> newList = new List<Image>();

        public trips()
        {
            g = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {

                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };

            Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            button = new Button()
            {
                Text = "Tagasi"
            };
            g.Children.Add(uus_mang, 0, 1);
            g.Children.Add(button, 0, 2);
            uus_mang.Clicked += Uus_mang_Clicked;
            Content = g;
        }



        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku Krestik-1 või Nolik-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (esimene_valik == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Uus_mang();

        }

        public async void Uus_mang()
        {
            bool uus = await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {
                Kes_on_esimene();
                int[,] Tulemused = new int[3, 3];
                tulemus = 2;
                g2 = new Grid
                {
                    BackgroundColor = Color.White,
                    RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                    ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }

                }
                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        img = new Image();
                        img.Source = ImageSource.FromFile("index.png");
                        g2.Children.Add(img, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        img.GestureRecognizers.Add(tap);
                    }
                }
                g.Children.Add(g2, 0, 0);
            }

        }

        public int Kontroll()
        {
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }

            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }

            else if (Tulemused[0, 0] == 0 && Tulemused[1, 0] == 0 && Tulemused[2, 0] == 0 || Tulemused[0, 1] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 1] == 0 || Tulemused[0, 2] == 0 && Tulemused[1, 2] == 0 && Tulemused[2, 2] == 0)
            {
                tulemus = 0;
            }
            else if (Tulemused[0, 0] == 0 && Tulemused[0, 1] == 0 && Tulemused[0, 2] == 0 || Tulemused[1, 0] == 0 && Tulemused[1, 1] == 0 && Tulemused[1, 2] == 0 || Tulemused[2, 0] == 0 && Tulemused[2, 1] == 0 && Tulemused[2, 2] == 0)
            {
                tulemus = 0;
            }
            else if (Tulemused[0, 0] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 2] == 0 || Tulemused[0, 2] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 0] == 0)
            {
                tulemus = 0;
            }


            return tulemus;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus == 1)
            {
                //DisplayAlert("Võit", "Krestik on võitja!", "Ok");
            }
            else if (tulemus == 0)
            {
                //DisplayAlert("Võit", "Nolik on võitja!", "Ok");
            }

        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var img = (Image)sender;
            var r = Grid.GetRow(img);
            var c = Grid.GetColumn(img);
            if (esimene == true)
            {
                img.Source = ImageSource.FromFile("krestik2.png");
                img.GestureRecognizers.Clear();
                esimene = false;
                Tulemused[r, c] = 1;
            }
            else
            {
                img.Source = ImageSource.FromFile("nolik2.png");
                img.GestureRecognizers.Clear();
                esimene = true;
                Tulemused[r, c] = 0;
            }
            g2.Children.Add(img, c, r);
            Lopp();

        }

    }
}
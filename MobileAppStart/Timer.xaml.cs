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
    public partial class Timer : ContentPage
    {
        public class Telefon
        {
            public string Nimetus { get; set; }
            public string Tootja { get; set; }
            public int Hind { get; set; }
            public string Picture { get; set; }
        }
        public List<Telefon> telefons { get; set; }

        ListView list;
        public Timer()
        {
            telefons = new List<Telefon>
            {
                new Telefon {Nimetus="Harjumaa", Tootja="Samsung", Hind=1349 },
                new Telefon {Nimetus="Ida Virumaa", Tootja="Xiaomi", Hind=399},
                new Telefon {Nimetus="Pärnumaa", Tootja="Xiaomi", Hind=339 },
                new Telefon {Nimetus="Hijumaa", Tootja="Apple", Hind=1179 }
            };
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                  {
                      ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                      imageCell.SetBinding(ImageCell.TextColorProperty, "Nimetus");
                      Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                      imageCell.SetBinding(ImageCell.TextColorProperty, companyBinding);
                      imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                      return imageCell;
                      Label nimetus = new Label { FontSize = 20 };
                      nimetus.SetBinding(Label.TextProperty, "Nimetus");

                      Label tootja = new Label();
                      tootja.SetBinding(Label.TextProperty, "Tootja");

                      Label hind = new Label();
                      hind.SetBinding(Label.TextProperty, "Hind");


                      return new ViewCell
                      {
                          View = new StackLayout
                          {
                              Padding = new Thickness(0, 5),
                              Orientation = StackOrientation.Vertical,
                              Children = { nimetus, tootja, hind }
                          }
                      };
                  })
            };

            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { list } };
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
        }
        private void LoadPhones()
        {
            if (Prefs.SavedList.Count <= 0)
            {
                telefons = new List<Telefon>
                {
                    new Telefon{ Nimetus = "Eesti", Tootja = "Tallinn", Hind = 600, Picture = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/Flag_of_Estonia.svg/1200px-Flag_of_Estonia.svg.png"},
                    new Telefon{ Nimetus = "Läti", Tootja = "Riga", Hind = 2000, Picture = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Flag_of_Latvia_with_border.svg/1280px-Flag_of_Latvia_with_border.svg.png"},
                    new Telefon{ Nimetus = "Leedu", Tootja = "Vilnus", Hind = 1500, Picture = "https://www.adaur.ee/wp-content/2018/02/Leedu-lipp.png"},
                    new Telefon{ Nimetus = "Soome", Tootja = "Helsinki", Hind = 300, Picture = "https://www.eures.ee/sites/eures.ee/files/2018-09/640px-Flag_of_Finland.svg_.png"},
                };
            }
            else
            {
                telefons = new List<Telefon>(Prefs.SavedList);
            }
            SaveCountries(telefons);
        }
        private void SaveCountries(List<Telefon> countryd)
        {
            var savedList = new List<Telefon>();
            foreach (Telefon country in countryd)
            {
                savedList.Add(country);
            }
            Prefs.SavedList = countryd;
            if (list != null)
                list.ItemsSource = countryd;
        }
        /*private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                lbl_list.Text = e.SelectedItem.ToString();
        }*/
        static class Prefs
        {
            public static List<Telefon> SavedList
            {
                get
                {
                    var savedList = Deserialize<List<Telefon>>(Preferences.Get(nameof(SavedList), ""));
                    return (List<Telefon>)(savedList ?? new List<Telefon>());
                }
                set
                {
                    var serializedList = Serialize(value);
                    Preferences.Set(nameof(SavedList), (string)serializedList);
                }
            }

            /*Entry url = new Entry
            {
                Placeholder = "Url",
                Keyboard = Keyboard.Default
            };*/
            private static object Serialize(List<Telefon> value)
            {
                throw new NotImplementedException();
            }

            private static object Deserialize<T>(object p)
            {
                throw new NotImplementedException();
            }
        }
    }
}
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
    public partial class Entry_Page : ContentPage
    {
        Editor ed;
        Label lb;

        public Entry_Page()
        {
            ed = new Editor
            {
                Placeholder = "Sisesta siis teksti",
                BackgroundColor = Color.White,
                TextColor = Color.Red
            };
            ed.TextChanged += Ed_TextChanged;
            lb = new Label
            {
                Text = "Mingi tekst",
                TextColor = Color.Black
            };
            Button tagasi = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.Salmon,
                TextColor = Color.Black
            };
            tagasi.Clicked += Tagasi_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { ed, lb, tagasi }
            };
            st.BackgroundColor = Color.PeachPuff;
            Content = st;
        }
        int i = 0;
        int k = 0;
        private void Ed_TextChanged(object sender, TextChangedEventArgs e)
        {
            ed.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key == 'N')
            {
                i++;
                
            }
            else
            {
                k++;
            }
            lb.Text = "N: " + i +"\nLetters: " + k;
            ed.TextChanged += Ed_TextChanged;
        }

        private async void Tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

       
    }
}
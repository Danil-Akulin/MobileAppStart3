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
    public partial class nende_Page : ContentPage
    {
        Picker picker, picker_2;
        StackLayout st;
        Image img;
        Button linkButton;
        List<string> maakonnad;
        List<string> linnad;
        List<string> links;
        string[] imgs;
        public nende_Page()
        {
            links = new List<string>() { "https://triptoestonia.com/ida-virumaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-jygevamaa/",                 //ссылки на краткую информацию
            "https://triptoestonia.com/harjumaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-yarvamaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-raplamaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-lyaenemaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-pyarnumaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-vilyandimaa/",
            "https://triptoestonia.com/et/valgamaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-vyrumaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-pylvamaa/",
            "https://triptoestonia.com/et/tartumaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-lyaene-virumaa/", "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-xijumaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-saaremaa/"};
             
            maakonnad = new List<string>() {    // список уездок 
                "Ida-Virumaa", "Jõgevamaa", "Harjumaa", "Järvamaa", "Raplamaa",
                "Läänemaa", "Pärnumaa", "Viljandimaa", "Valgamaa", "Võrumaa",
                "Põlvamaa", "Tartumaa", "Lääne-Virumaa", "Hiiumaa", "Saaremaa"};
            linnad = new List<string>() {   // список городов
                "Jõhvi", "Jõgeva", "Tallinn", "Paide", "Rapla",
                "Haapsalu", "Pärnu", "Viljandi", "Valga", "Võru",
                "Põlva", "Tartu", "Rakvere", "Kärdla", "Kuressaare"};

            imgs = new string[] {     //список картинок городов
                "Ida.jpg", 
                "Joge.jpg",
                "Harjumaa.jpg",
                "Jarvamaa.jpg",
                "Raplamaa.png",
                "Laanemaa.jpg",
                "Parnumaa.jpg",
                "Viljandi.jpg",
                "Valgamaa.jpg",
                "Voru.jpg",
                "Polvamaa.jpg",
                "Tartumaa.jpg",
                "LaaneViirumaa.jpg",
                "Hiiumaa.png",
                "Saaremaa.jpg"
            };

            picker = new Picker       //список уездов
            {
                Title = "Maakonnad"
            };

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            picker_2 = new Picker    //список городов
            {
                Title = "Linnad"
            };

            picker_2.SelectedIndexChanged += Picker_2_SelectedIndexChanged;


            img = new Image() { Source = " " };

            linkButton = new Button()
            {
                Text = " "
            };
            linkButton.IsVisible = false;
            linkButton.Clicked += LinkButton_Clicked;


            Button tagasi = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.Salmon,
                TextColor = Color.Black
            };



            st = new StackLayout { Children = { picker, picker_2, img, linkButton, tagasi } };
            Content = st;

            for (int i = 0; i < maakonnad.Count; i++)
            {
                picker.Items.Add(maakonnad[i]);
                picker_2.Items.Add(linnad[i]);
            }

        }


        private async void LinkButton_Clicked(object sender, EventArgs e)  //функция для открытия ссылки на краткую информацию
        {
            await Browser.OpenAsync(links[picker.SelectedIndex], BrowserLaunchMode.SystemPreferred);
        }

        private void Picker_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker.SelectedIndex = picker_2.SelectedIndex;
            ChangeImg(picker.SelectedIndex);
            linkButton.Text = $"Info: {maakonnad[picker.SelectedIndex]}";
            linkButton.IsVisible = true;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker_2.SelectedIndex = picker.SelectedIndex;
            ChangeImg(picker.SelectedIndex);
            linkButton.Text = $"Info: {maakonnad[picker.SelectedIndex]}";
            linkButton.IsVisible = true;
        }

        private void ChangeImg(int index) 
        {
            img.Source = imgs[index];
        }
    }
}
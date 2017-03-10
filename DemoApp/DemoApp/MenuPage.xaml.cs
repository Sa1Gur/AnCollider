using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ancollider
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        void Button_OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            //var currentMasterDetailPage = Application.Current.MainPage as NewMainPage;
            //var _DetailPage = currentMasterDetailPage.Detail as DetailPage;
            
            switch (button?.AutomationId)
            {
                case "main":
                    //_DetailPage._PopUpLayout.DismissPopup();
                    //this.
                    //IsVisible = false;
                    break;
                case "about":
                    DisplayAlert("Андроидный коллайдер", "Творческая группа \"Андроидный коллайдер\" образована московскими художниками, архитекторами, которые создают арт-обЪекты, инсталляции, обращенные как к отвлеченным патетическим переживаниям лирических героев, так и к отношению самих авторов к проблемам культурно-исторического наследия\n\ncolliderdroid@gmail.com", "Ок");
                    //Creative union "Android Collider" founded by Moscow artists and architects is aimed at creation of art objects, installations, facing both the abstract pathetic lyrical characters' experience, and authors' regarding to cultural and historical heritage problems 
                    //currentMasterDetailPage.Detail = new NavigationPage(new ContentPage { BackgroundColor = Color.Lime });
                    break;
            }
        }
    }
}

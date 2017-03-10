using Xamarin.Forms;

namespace ancollider
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(): base(new DetailPage())
        {
        }
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NewMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

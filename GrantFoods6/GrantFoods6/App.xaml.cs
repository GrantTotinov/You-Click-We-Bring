using GrantFoods6.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrantFoods6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new LoginView();
            //MainPage = new NavigationPage(new SettingsPage());
            Device.SetFlags(new string[] { "MediaElement_Experimental", "Brush_Experimental", "IndicatorView_Experimental","Shapes_Experimental" });

            MainPage = new RegisterView();


            /*string uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ProductsView();
            }*/

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

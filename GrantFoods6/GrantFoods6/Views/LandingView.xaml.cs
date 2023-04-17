using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Timer = System.Timers.Timer;


namespace GrantFoods6.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingView : ContentPage
    {
        public LandingView()
        {
            InitializeComponent();
            AnimateCarousel();
        }
        Timer timer;
        private void AnimateCarousel()
        {
            timer = new System.Timers.Timer(5000) { AutoReset = true, Enabled = true };

            timer.Elapsed += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (cvOnboarding.Position == 2)
                    {
                        cvOnboarding.Position = 0;
                        return;
                    }
                    cvOnboarding.Position += 1;
                });
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new RegisterView());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginView());
        }
    }
}
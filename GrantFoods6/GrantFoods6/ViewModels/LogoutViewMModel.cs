using GrantFoods6.Services;
using GrantFoods6.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GrantFoods6.ViewModels
{
    public class LogoutViewMModel : BaseViewModel
    {
        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserCartItemsCount;
            }
        }
                   

        private bool _IsCartExist;
        public bool IsCartExist
        {
            set
            {
                _IsCartExist = value;
                OnPropertyChanged();
            }
            get
            {
                return _IsCartExist;  
            }
        }

        public Command LogoutCommand { get; set; }
        public Command GotoCartCommmand { get; set; }

        public LogoutViewMModel()
        {
            UserCartItemsCount = new CartItemService().GetUserCartCount();
            IsCartExist = (UserCartItemsCount > 0)? true : false;

            LogoutCommand = new Command(async () => await LogoutUserAsync());
            GotoCartCommmand = new Command(async () => await GotoCartAsync());
        }

        private async Task GotoCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutUserAsync()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}

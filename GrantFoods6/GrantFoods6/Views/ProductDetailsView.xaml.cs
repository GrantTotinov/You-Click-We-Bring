using GrantFoods6.Models;
using GrantFoods6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrantFoods6.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsView : ContentPage
    {
        ProductDatailsViewModel pvm;
        public ProductDetailsView(FoodItem fooditem)
        {
            InitializeComponent();
            pvm = new ProductDatailsViewModel(fooditem);
            this.BindingContext = pvm;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
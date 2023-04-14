﻿using GrantFoods6.Models;
using GrantFoods6.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrantFoods6.ViewModels
{
    public class ProductDatailsViewModel : BaseViewModel
    {
		private FoodItem _SelectedFoodItem;
		public FoodItem SelectedFoodItem
		{
			set
			{
				_SelectedFoodItem = value;
				OnPropertyChanged();
			}
			get
			{
				return _SelectedFoodItem;
			}
		}

        private int _TotalQuantity;
        public int TotalQuantity
        {
            set
            {
                this._TotalQuantity = value;
                if (this._TotalQuantity < 0)
                    this._TotalQuantity = 0;
                if (this._TotalQuantity > 10)
                    this._TotalQuantity -= 1;
                OnPropertyChanged();
            }
            get
            {
                return _TotalQuantity;
            }
        }

        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }

        public ProductDatailsViewModel(FoodItem foodItem)
        {
            SelectedFoodItem = foodItem;
            TotalQuantity = 0;
            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async() => await ViewCartAsync());
            HomeCommand = new Command(async () => await GoToHomeAsync());
        }

        private async Task GoToHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private void AddToCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem ci = new CartItem()
                {
                    ProductId = SelectedFoodItem.ProductID,
                    ProductName = SelectedFoodItem.Name,
                    Price = SelectedFoodItem.Price,
                    Quantity = TotalQuantity
                };
                var item = cn.Table<CartItem>().ToList().FirstOrDefault(c => c.ProductId == SelectedFoodItem.ProductID);
                if (item == null)
                    cn.Insert(ci);
                else
                {
                    item.Quantity += TotalQuantity;
                    cn.Update(item);
                }
                cn.Commit();
                cn.Close();
                Application.Current.MainPage.DisplayAlert("Cart","Selected Item is Added to the Cart", "OK");

            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                cn.Close();
            }
        }

        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
    }
}
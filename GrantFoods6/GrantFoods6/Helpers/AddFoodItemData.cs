using Firebase.Database;
using Firebase.Database.Query;
using GrantFoods6.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrantFoods6.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://grantfoods6-default-rtdb.europe-west1.firebasedatabase.app/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = "",
                    Name = "ChefBurger1",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = "",
                    Name = "ChefBurger2",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 3,
                    CategoryID = 1,
                    ImageUrl = "",
                    Name = "ChefBurger3",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 4,
                    CategoryID = 1,
                    ImageUrl = "",
                    Name = "ChefBurger4",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 5,
                    CategoryID = 2,
                    ImageUrl = "",
                    Name = "ChefBurger5",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 6,
                    CategoryID = 2,
                    ImageUrl = "",
                    Name = "ChefBurger6",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 7,
                    CategoryID = 3,
                    ImageUrl = "",
                    Name = "ChefBurger7",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 8,
                    CategoryID = 3,
                    ImageUrl = "",
                    Name = "ChefBurger8",
                    Description = "Fast Food",
                    Rating = "4.8",
                    RatingDetail = "(33 213 raitigs)",
                    Homeselected = "CompleteHeart",
                    Price = 45
                },
            };
        }

        public async Task AddFoodItemsAsync()
        {
            try
            {
                foreach( var item in FoodItems)
                {
                    await client.Child("FoodsItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Description = item.Description,
                        Homeselected = item.Homeselected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail,
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
            }
        }
        
    }
    
}

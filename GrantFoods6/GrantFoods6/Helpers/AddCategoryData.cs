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
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient client;
        public AddCategoryData()
        {
            client = new FirebaseClient("https://grantfoods6-default-rtdb.europe-west1.firebasedatabase.app/");
            Categories = new List<Category>()
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Burger",
                    CategoryPoster = "MainBurger",
                    ImageUrl=""
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Pizza",
                    CategoryPoster = "MainPizza",
                    ImageUrl=""
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Desert",
                    CategoryPoster = "MainDesert",
                    ImageUrl=""
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "VegBurger",
                    CategoryPoster = "MainBurger",
                    ImageUrl=""
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Veg Pizza",
                    CategoryPoster = "MainBurger",
                    ImageUrl=""
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Cakes",
                    CategoryPoster = "MainCakes",
                    ImageUrl=""
                }

            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
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

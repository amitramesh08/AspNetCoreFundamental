using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ToDoOdt.Core;
using ToDoOdt.Data;

namespace ToDoOdt.Pages.Restaurants
{
    public class List : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;
        public List<Restaurant> Restarants { get;  set; }

        public List(IConfiguration configuration,IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }

        public void OnGet(string restaurantName)
        {
            Restarants = _restaurantData.GetAllRestaurantByName(restaurantName).ToList();
        }
    }
}
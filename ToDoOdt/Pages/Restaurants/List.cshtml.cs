using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        [BindProperty(SupportsGet = true)]
        public string  RestaurantName { get; set; }

        public List(IConfiguration configuration,IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restarants = _restaurantData.GetAllRestaurantByName(RestaurantName).ToList();
        }

        // public IActionResult OnDetete(int restaurantId)
        // {
        //     var rest =  _restaurantData.DeleteRastaurant(restaurantId);
        //     return new OkObjectResult(rest);
        // }
    }
}
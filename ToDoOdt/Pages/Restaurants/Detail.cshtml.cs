using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoOdt.Core;
using ToDoOdt.Data;

namespace ToDoOdt.Pages.Restaurants
{
    public class Detail : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; private set; }
        public Detail(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public void OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
        }
    }
}
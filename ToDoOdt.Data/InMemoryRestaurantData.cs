using System.Collections.Generic;
using System.Linq;
using ToDoOdt.Core;

namespace ToDoOdt.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly IEnumerable<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1,Name = "Piza Mania",Location = "India",Cuisine = CuisineType.Indian},
                new Restaurant{Id = 1,Name = "Pape",Location = "India",Cuisine = CuisineType.Indian},
                new Restaurant{Id = 1,Name = "Coutery Special",Location = "India",Cuisine = CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetAllRestaurant()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}
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
                new Restaurant{Id = 2,Name = "Pape",Location = "India",Cuisine = CuisineType.Indian},
                new Restaurant{Id = 3,Name = "Coutery Special",Location = "India",Cuisine = CuisineType.Indian}
            };
        }
        
        public IEnumerable<Restaurant> GetAllRestaurantByName(string restaurantName)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return _restaurants;
            }
            return _restaurants
                .Where(x=>!string.IsNullOrEmpty(x.Name) && x.Name.StartsWith(restaurantName))
                .OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return _restaurants.Single(x => x.Id.Equals(restaurantId));
        }
    }
}
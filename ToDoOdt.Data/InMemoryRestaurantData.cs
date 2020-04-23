using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using ToDoOdt.Core;

namespace ToDoOdt.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

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
            return _restaurants.SingleOrDefault(x => x.Id.Equals(restaurantId));
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var restaurantUpdate= _restaurants.SingleOrDefault(x => x.Id.Equals(restaurant.Id));
            if (restaurantUpdate == null)
            {
                return null;
            }
            restaurantUpdate.Name = restaurant.Name;
            restaurantUpdate.Location = restaurant.Location;
            restaurantUpdate.Cuisine = restaurant.Cuisine;

            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }
        public Restaurant DeleteRastaurant(int restaurantId)
        {
            var restaurant = _restaurants.SingleOrDefault(x => x.Id.Equals(restaurantId));
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using ToDoOdt.Core;

namespace ToDoOdt.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurantByName(string restaurantName);
        Restaurant GetRestaurantById(int restaurantId);
        Restaurant UpdateRestaurant(Restaurant restaurant);
        Restaurant AddRestaurant(Restaurant restaurant);

    }
}
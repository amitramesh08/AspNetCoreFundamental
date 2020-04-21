using System.Collections;
using System.Collections.Generic;
using ToDoOdt.Core;

namespace ToDoOdt.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurantByName(string restaurantName);
    }
}
using Microsoft.AspNetCore.Mvc;
using ToDoOdt.Data;

namespace ToDoOdt.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        // GET
       
 // public IActionResult Index()
        // {
        //     return View();
        // }
        // api/restaurants
        
        [HttpPost]
        //[Route("/api/Rest")]
        public IActionResult GetRestaurants()
        {
            var restaurants = _restaurantData.GetRestaurantById(1);
            return Ok(restaurants);
            
            //return Json(dataTable, JsonRequestBehavior.AllowGet);
        }
    }
}
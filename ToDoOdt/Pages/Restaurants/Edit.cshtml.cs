using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoOdt.Core;
using ToDoOdt.Data;

namespace ToDoOdt.Pages.Restaurants
{
    public class Edit : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        public IEnumerable<SelectListItem> CuisineList { get; set; }
        [BindProperty] public Restaurant Restaurant { get; set; }

        public Edit(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
            Restaurant = new Restaurant();
            CuisineList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            CuisineList = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Restaurant.Id > 0)
                {
                    var reactantUpdate = _restaurantData.UpdateRestaurant(Restaurant);
                }
                else
                {
                    _restaurantData.AddRestaurant(Restaurant);
                    RedirectToPage("./List");
                }
            }
            else
            {
                CuisineList = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            CuisineList = _htmlHelper.GetEnumSelectList<CuisineType>();
            return RedirectToPage("./Detail", new {restaurantId= Restaurant.Id});
        }
    }
}
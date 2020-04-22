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
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public Edit(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
            Restaurant = new Restaurant();
            CuisineList = new List<SelectListItem>();
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            CuisineList = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var reactantUpdate = _restaurantData.UpdateRestaurant(Restaurant);
            if (reactantUpdate == null)
            {
                RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
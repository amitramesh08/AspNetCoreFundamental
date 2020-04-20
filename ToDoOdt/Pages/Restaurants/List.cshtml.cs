using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ToDoOdt.Pages.Restaurants
{
    public class List : PageModel
    {
        private readonly IConfiguration _configuration;

        public List(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string MessageData { get; set; }
        
        public void OnGet()
        {
            MessageData = _configuration["MessageData"];
        }
    }
}
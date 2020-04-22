using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoOdt.Core;

namespace ToDoOdt.Data
{
    public class ToDoTdoDbContext : DbContext
    {
        private string _connectionString = string .Empty;
       
        
        public ToDoTdoDbContext(DbContextOptions<ToDoTdoDbContext> options) : base(options)
        {
            
        }
        private DbSet<Restaurant> Restaurants { get; set; }
        
    }
}
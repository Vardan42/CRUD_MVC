using CRUD__MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD__MVC.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            :base(options)
        {

        }
        public DbSet<Product> Products  { get; set; }
    }
}

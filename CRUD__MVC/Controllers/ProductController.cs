using CRUD__MVC.Data;
using CRUD__MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD__MVC.Controllers
{
    public class ProductController : Controller
    {
      private readonly AppDbContext appDbContext ;

        public ProductController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(appDbContext.Products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await appDbContext.Products.AddAsync(product);

                await appDbContext.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }
            return View(product);
        }  
        public async Task<IActionResult> Edit(int id)
        {
            var find=await appDbContext.Products.FindAsync(id);

            return View(find);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                  appDbContext.Products.Update(product);

                await appDbContext.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }
            return View(product);
        }public async Task<IActionResult> Delete(int id)
        {
            var find=await appDbContext.Products.FindAsync(id);

            return View(find);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int?id)
        {
            var delete = await appDbContext.Products.FindAsync(id);

            if (ModelState.IsValid)
            {
                  appDbContext.Products.Remove(delete);

                await appDbContext.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }
            return View(delete);
        }
    }
}

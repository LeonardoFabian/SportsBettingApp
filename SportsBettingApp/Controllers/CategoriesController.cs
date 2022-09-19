using Microsoft.AspNetCore.Mvc;
using SportsBettingApp.Models;

namespace SportsBettingApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categories category)
        {
            if( !ModelState.IsValid)
            {
                return View(category);
            }
            return View();
        }
    }
}

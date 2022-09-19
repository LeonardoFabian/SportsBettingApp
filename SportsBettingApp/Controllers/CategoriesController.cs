using Microsoft.AspNetCore.Mvc;
using SportsBettingApp.Models;
using SportsBettingApp.Services;

namespace SportsBettingApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categories category)
        {
            if ( !ModelState.IsValid)
            {
                return View(category);
            }

            await categoriesRepository.Create(category);

            return View();
        }
    }
}

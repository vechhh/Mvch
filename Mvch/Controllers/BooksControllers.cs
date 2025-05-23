using Microsoft.AspNetCore.Mvc;

namespace Mvch.Controllers
{
    public class BooksControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

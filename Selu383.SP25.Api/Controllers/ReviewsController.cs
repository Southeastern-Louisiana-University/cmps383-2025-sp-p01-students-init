using Microsoft.AspNetCore.Mvc;

namespace Selu383.SP25.Api.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

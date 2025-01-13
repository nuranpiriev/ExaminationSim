using Examination.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Examination.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Dashboard : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }
    }
}

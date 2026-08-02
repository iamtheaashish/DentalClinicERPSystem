using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        var model = new DashboardViewModel();
        return View(model);
    }
}

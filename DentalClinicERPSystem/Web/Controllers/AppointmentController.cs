using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class AppointmentController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
}

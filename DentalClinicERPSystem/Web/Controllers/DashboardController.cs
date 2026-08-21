using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize(Roles = "Reception,Admin,Dentist")]
public class DashboardController : Controller
{
    private readonly IDashboardService _dashboardService;
    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
}

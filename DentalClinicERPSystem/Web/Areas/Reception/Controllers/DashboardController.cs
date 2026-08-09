using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Reception.Controllers;

[Area("Reception")]
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

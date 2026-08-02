using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers;

public class DashboardController : Controller
{
    private readonly IDashboardService _dashboardService;
    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }
    public async Task<IActionResult> Index()
    {
        var viewModel = new DashboardViewModel();

        return View(viewModel);
    }
}

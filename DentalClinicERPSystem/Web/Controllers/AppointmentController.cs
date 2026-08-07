using Business.DTO;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class AppointmentController : Controller
{
    private readonly IAppointmentService _appointmentService;
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<IActionResult> Index()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();
        return View(appointments);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAppointmentDto createAppointmentDto)
    {
        if(!ModelState.IsValid)
        {
            return View(createAppointmentDto);
        }

        await _appointmentService.CreateAppointmentAsync(createAppointmentDto);

        return RedirectToAction(nameof(Index));
    }
}

using Business.DTO;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Reception.Controllers;

[Area("Reception")]
[Authorize(Roles = "Reception,Admin,Dentist")]
public class AppointmentController : Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    public AppointmentController(IAppointmentService appointmentService, IPatientService patientService)
    {
        _appointmentService = appointmentService;
        _patientService = patientService;
    }

    public async Task<IActionResult> Index()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();
        return View(appointments);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var patients = await _patientService.GetRecentPatientAsync();

        var model = new CreateAppointmentDto
        {
            Patients = patients
        };

        return View(model);
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

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if(appointment == null)
        {
            return NotFound();
        }
        return View(appointment);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        var updateDto = new UpdateAppointmentDto
        {
            ScheduledDateTime = appointment.ScheduledDateTime,
            DurationInMinutes = appointment.DurationInMinutes,
            AppointmentType = appointment.AppointmentType,
            ChiefComplaint = appointment.ChiefComplaint,
            Notes = appointment.Notes,
            Status = appointment.Status,
            DentistId = appointment.DentistId
        };
        return View(updateDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, UpdateAppointmentDto updateAppointmentDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updateAppointmentDto);
        }
        await _appointmentService.UpdateAppointmentAsync(id, updateAppointmentDto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        return View(appointment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }

        await _appointmentService.DeleteAppointmentAsync(id);

        return RedirectToAction(nameof(Index));
    }


}

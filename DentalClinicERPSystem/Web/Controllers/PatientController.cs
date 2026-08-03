using Business.DTO;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class PatientController : Controller
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var patients = await _patientService.GetAllPatientsAsync();
        return View(patients);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePatientDto createPatientDto)
    {
        if(!ModelState.IsValid)
        {
            return View(createPatientDto);
        }
        await _patientService.CreatePatientAsync(createPatientDto);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var patientDetails = await _patientService.GetPatientByIdAsync(id);
        return View(patientDetails);
    }


}

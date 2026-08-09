using Business.DTO;
using Business.Interfaces;
using DentalClinicERPSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Reception.Controllers;

[Area("Reception")]
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

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var patient = await _patientService.GetPatientByIdAsync(id);

        if (patient == null)
        {
            return NotFound();
        }

        // Map PatientDto -> UpdatePatientDto to match @model UpdatePatientDto in the View
        var updateDto = new UpdatePatientDto
        {
            Id = patient.Id,
            AadhaarId = patient.AadhaarId,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Email = patient.Email,
            PhoneN1 = patient.PhoneN1,
            PhoneN2 = patient.PhoneN2,
            EmergencyPhone = patient.EmergencyPhone,
            HomeAddress = patient.HomeAddress,
            DateOfBirth = patient.DateOfBirth
        };

        return View(updateDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, UpdatePatientDto updatePatientDto)
    {
        // Security check: ensure URL route id matches the form payload ID
        if (id != updatePatientDto.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(updatePatientDto);
        }

        await _patientService.UpdatePatientAsync(id, updatePatientDto);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var patient = await _patientService.GetPatientByIdAsync(id);

        if (patient == null)
        {
            return NotFound();
        }

        return View(patient);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var patient = await _patientService.GetPatientByIdAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        await _patientService.DeletePatientAsync(id);

        return RedirectToAction(nameof(Index));
    }

}

using Business.DTO;
using Business.Interfaces;
using DentalClinicERPSystem.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services;

public class PatientService : IPatientService
{
    private readonly ApplicationDbContext _context;

    public PatientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> DeletePatientAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<int> IPatientService.CreatePatientAsync(CreatePatientDto createPatientDto)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<PatientDto>> IPatientService.GetAllPatientsAsync()
    {
        throw new NotImplementedException();
    }

    Task<PatientDto?> IPatientService.GetPatientByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<bool> IPatientService.UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto)
    {
        throw new NotImplementedException();
    }
}

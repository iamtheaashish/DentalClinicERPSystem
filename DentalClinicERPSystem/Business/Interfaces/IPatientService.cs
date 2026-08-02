using Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces;

public interface IPatientService
{
    // Get all patients
    Task<IEnumerable<PatientDto>> GetAllPatientsAsync();

    // Get single patient by ID
    Task<PatientDto?> GetPatientByIdAsync(int id);

    // Create a new patient
    Task<int> CreatePatientAsync(CreatePatientDto createPatientDto);

    // Update existing patient
    Task<bool> UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto);

    // Delete patient
    Task<bool> DeletePatientAsync(int id);
}

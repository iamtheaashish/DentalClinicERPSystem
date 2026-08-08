using Business.DTO;
using Business.Interfaces;
using DentalClinicERPSystem.DataAccess.Data;
using DentalClinicERPSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class PatientService : IPatientService
{
    private readonly ApplicationDbContext _context;

    public PatientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DeletePatientAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
        {
            return false;
        }

        _context.Patients.Remove(patient);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<int> CreatePatientAsync(CreatePatientDto createPatientDto)
    {
        var patient = new Patient
        {
            AadhaarId = createPatientDto.AadhaarId,
            FirstName = createPatientDto.FirstName,
            LastName = createPatientDto.LastName,
            Email = createPatientDto.Email,
            PhoneN1 = createPatientDto.PhoneN1,
            PhoneN2 = createPatientDto.PhoneN2,
            EmergencyPhone = createPatientDto.EmergencyPhone,
            HomeAddress = createPatientDto.HomeAddress,
            DateOfBirth = createPatientDto.DateOfBirth,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Patients.AddAsync(patient);

        await _context.SaveChangesAsync();

        return patient.Id;
    }

    public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
    {
        return await _context.Patients
            .AsNoTracking()
            .Select(p => new PatientDto
            {
                Id = p.Id,
                AadhaarId = p.AadhaarId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneN1 = p.PhoneN1,
                PhoneN2 = p.PhoneN2,
                EmergencyPhone = p.EmergencyPhone,
                HomeAddress = p.HomeAddress,
                DateOfBirth = p.DateOfBirth,
                CreatedAt = p.CreatedAt,
            }).ToListAsync();
    }

    public async Task<PatientDto?> GetPatientByIdAsync(int id)
    {
        return await _context.Patients
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new PatientDto
            {
                Id = p.Id,
                AadhaarId = p.AadhaarId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneN1 = p.PhoneN1,
                PhoneN2 = p.PhoneN2,
                EmergencyPhone = p.EmergencyPhone,
                HomeAddress = p.HomeAddress,
                DateOfBirth = p.DateOfBirth,
                CreatedAt = p.CreatedAt
            }).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return false;
        }

        patient.AadhaarId = updatePatientDto.AadhaarId;
        patient.FirstName = updatePatientDto.FirstName;
        patient.LastName = updatePatientDto.LastName;
        patient.Email = updatePatientDto.Email;
        patient.PhoneN1 = updatePatientDto.PhoneN1;
        patient.PhoneN2 = updatePatientDto.PhoneN2;
        patient.EmergencyPhone = updatePatientDto.EmergencyPhone;
        patient.HomeAddress = updatePatientDto.HomeAddress;
        patient.DateOfBirth = updatePatientDto.DateOfBirth;
        // we're not touching created at and id

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<IEnumerable<PatientLookup>> GetRecentPatientAsync()
    {
        var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

        var patients = await _context.Patients
            .Where(p => p.CreatedAt >= sevenDaysAgo)
            .Select(p => new PatientLookup
            {
                Id = p.Id,
                FirstName = p.FirstName
            }).ToListAsync();
        return patients;
    }
}

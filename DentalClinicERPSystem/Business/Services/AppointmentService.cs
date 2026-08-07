using Business.DTO;
using Business.Interfaces;
using DentalClinicERPSystem.DataAccess.Data;
using DentalClinicERPSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services;

public class AppointmentService : IAppointmentService
{
    private readonly ApplicationDbContext _context;
    
    public AppointmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
    {
        var appointment = new Appointment
        {
            PatientId = createAppointmentDto.PatientId,
            DentistId = createAppointmentDto.DentistId,
            ScheduledDateTime = createAppointmentDto.ScheduledDateTime,
            DurationInMinutes = createAppointmentDto.DurationInMinutes,
            AppointmentType = createAppointmentDto.AppointmentType,
            Status = createAppointmentDto.Status,
            ChiefComplaint = createAppointmentDto.ChiefComplaint,
            Notes = createAppointmentDto.Notes,
        };

        await _context.Appointments.AddAsync(appointment);

        await _context.SaveChangesAsync();

        return appointment.Id;
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
    {
        return await _context.Appointments
        .AsNoTracking()
        .Select(p => new AppointmentDto
        {
            Id = p.Id,
            PatientId = p.PatientId,
            ScheduledDateTime = p.ScheduledDateTime,
            DurationInMinutes = p.DurationInMinutes,
            AppointmentType = p.AppointmentType,
            Status = p.Status,
            DentistId = p.DentistId,
            CreatedAt = p.CreatedAt,
        }).ToListAsync();

    }

    public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto)
    {
        throw new NotImplementedException();
    }
}

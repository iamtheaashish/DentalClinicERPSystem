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
            PatientName = p.Patient.FirstName,
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
        return await _context.Appointments
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new AppointmentDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                PatientName = p.Patient.FirstName + " " + p.Patient.LastName,
                ScheduledDateTime =  p.ScheduledDateTime,
                DurationInMinutes = p.DurationInMinutes,
                AppointmentType = p.AppointmentType,
                ChiefComplaint = p.ChiefComplaint,
                Notes = p.Notes,
                Status = p.Status,
                DentistId = p.DentistId,
                CreatedAt = p.CreatedAt,                
            }).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return false;
        }

        appointment.ScheduledDateTime = updateAppointmentDto.ScheduledDateTime;
        appointment.DurationInMinutes = updateAppointmentDto.DurationInMinutes;
        appointment.AppointmentType = updateAppointmentDto.AppointmentType;
        appointment.ChiefComplaint = updateAppointmentDto.ChiefComplaint;
        appointment.Notes = updateAppointmentDto.Notes;
        appointment.DentistId = updateAppointmentDto.DentistId;

        var result = await _context.SaveChangesAsync();

        return result > 0;

    }
}

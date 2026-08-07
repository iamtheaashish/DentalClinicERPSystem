using Business.DTO;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services;

public class AppointmentService : IAppointmentService
{
    public Task<int> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAppointmentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto)
    {
        throw new NotImplementedException();
    }
}

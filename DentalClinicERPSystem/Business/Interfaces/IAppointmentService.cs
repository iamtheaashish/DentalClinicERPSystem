using Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
    Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
    Task<int> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto);
    Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto);
    Task<bool> DeleteAppointmentAsync(int id);
}

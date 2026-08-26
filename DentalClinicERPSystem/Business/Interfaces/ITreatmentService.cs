using Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces;

public interface ITreatmentService
{
    Task<IEnumerable<TreatmentDto>> GetAllTreatmentsAsync();
    Task<TreatmentDto?> GetTreatmentByIdAsync(int id);
    Task<int> CreateTreatmentAsync(CreateTreatmentDto createTreatmentDto);
    Task<bool> UpdateTreatmentAsync(int id, UpdateTreatmentDto updateTreatmentDto);
    Task<bool> DeleteTreatmentAsync(int id);
}

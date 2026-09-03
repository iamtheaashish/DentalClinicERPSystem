using Business.DTO;
using Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services;

public class TreatmentService : ITreatmentService
{
    public Task<int> CreateTreatmentAsync(CreateTreatmentDto createTreatmentDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTreatmentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TreatmentDto>> GetAllTreatmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TreatmentDto?> GetTreatmentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateTreatmentAsync(int id, UpdateTreatmentDto updateTreatmentDto)
    {
        throw new NotImplementedException();
    }
}

using System;
using Domain.Entities;

namespace Business.DTO;

public class TreatmentDto
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string DentistId { get; set; } = string.Empty;

    public int? AppointmentId { get; set; }

    public DateTime TreatmentDate { get; set; }

    public string Diagnosis { get; set; } = string.Empty;

    public string TreatmentDescription { get; set; } = string.Empty;

    public string? Notes { get; set; }

    public TreatmentStatus Status { get; set; }

    public decimal Cost { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
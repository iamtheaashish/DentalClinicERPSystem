using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Business.DTO;

public class UpdateTreatmentDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int PatientId { get; set; }

    [Required]
    public string DentistId { get; set; } = string.Empty;

    public int? AppointmentId { get; set; }

    [Required]
    public DateTime TreatmentDate { get; set; }

    [Required, StringLength(500)]
    public string Diagnosis { get; set; } = string.Empty;

    [Required, StringLength(2000)]
    public string TreatmentDescription { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Notes { get; set; }

    [Required]
    public TreatmentStatus Status { get; set; }

    [Range(0, 99999999)]
    public decimal Cost { get; set; }
}
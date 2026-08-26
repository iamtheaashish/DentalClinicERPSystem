using DentalClinicERPSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Treatment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;

    [Required]
    public string DentistId { get; set; }

    [ForeignKey(nameof(ApplicationUser.Id))]
    public ApplicationUser Dentist { get; set; } = null!;

    public int? AppointmentId { get; set; }

    [ForeignKey(nameof(AppointmentId))]
    public Appointment? Appointment { get; set; }

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

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

public enum TreatmentStatus
{
    Planned,
    InProgress,
    Completed,
    Cancelled
}
using System.ComponentModel.DataAnnotations;
using DentalClinicERPSystem.Domain.Entities;

namespace Business.DTO;

public class CreateAppointmentDto
{
    [Required]
    public int PatientId { get; set; }

    [Required]
    public DateTime ScheduledDateTime { get; set; } = DateTime.UtcNow;

    [Required]
    [Range(1, 480)]
    public int DurationInMinutes { get; set; } = 30;

    public DateTime EndTime => ScheduledDateTime.AddMinutes(DurationInMinutes);

    [Required]
    [StringLength(100)]
    public string AppointmentType { get; set; } = string.Empty;

    [StringLength(500)]
    public string? ChiefComplaint { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    public AppointmentStatus Status { get; set; }

    public string? DentistId { get; set; }
    public IEnumerable<UserListDto>? Dentists { get; set; }
    public IEnumerable<PatientLookup>? Patients { get; set; }
}

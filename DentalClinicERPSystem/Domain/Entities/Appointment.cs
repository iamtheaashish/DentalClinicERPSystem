using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinicERPSystem.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;

        [Required]
        public DateTime ScheduledDateTime { get; set; }

        [Required]
        public int DurationInMinutes { get; set; } = 30;

        [NotMapped]
        public DateTime EndTime => ScheduledDateTime.AddMinutes(DurationInMinutes);

        [Required]
        [StringLength(100)]
        public string AppointmentType { get; set; } = string.Empty;
        // e.g., "Routine Checkup", "Root Canal", "Cleaning", "Emergency", "Consultation"

        [StringLength(500)]
        public string? ChiefComplaint { get; set; }
        // Reason for visit / symptoms (e.g., "Pain in upper right molar")

        [StringLength(500)]
        public string? Notes { get; set; }
        // Receptionist/Internal notes (e.g., "Patient prefers morning slots", "Requires wheelchair access")

        // --- Status ---
        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

        public string? DentistId { get; set; }

        [ForeignKey(nameof(DentistId))]
        public ApplicationUser? Dentist { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum AppointmentStatus
    {
        Scheduled = 1,
        Confirmed = 2,
        InQueue = 3,      // Patient arrived at clinic waiting room
        InProgress = 4,   // Patient inside dentist room
        Completed = 5,
        Cancelled = 6,
        NoShow = 7        // Patient missed appointment without cancelling
    }
}
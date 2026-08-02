using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DTO;

public class UpdatePatientDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(12, MinimumLength = 12)]
    public string AadhaarId { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [EmailAddress]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    [Display(Name = "Primary Contact")]
    [StringLength(10)]
    public string PhoneN1 { get; set; } = string.Empty;

    [Phone]
    [Display(Name = "Secondary Contact")]
    [StringLength(10)]
    public string? PhoneN2 { get; set; }

    [Phone]
    [Display(Name = "Emergency Phone Number")]
    [StringLength(10)]
    public string? EmergencyPhone { get; set; }

    [StringLength(500)]
    [Display(Name = "Home Address")]
    public string? HomeAddress { get; set; }

    [Required]
    public DateOnly DateOfBirth { get; set; }
}


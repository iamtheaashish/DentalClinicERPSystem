using DentalClinicERPSystem.DataAccess.Data;
using DentalClinicERPSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Web.Seeders;

public static class TestDataSeeder
{
    public static async Task SeedAsync(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager)
    {
        if (!await context.Patients.AnyAsync())
        {
            var patients = new List<Patient>
            {
                new()
                {
                    AadhaarId = "234567890123",
                    FirstName = "Rahul",
                    LastName = "Verma",
                    Email = "rahul.verma@example.com",
                    PhoneN1 = "9876543210",
                    DateOfBirth = new DateOnly(1995, 4, 12),
                    HomeAddress = "Rohini, Delhi"
                },
                new()
                {
                    AadhaarId = "345678901234",
                    FirstName = "Neha",
                    LastName = "Sharma",
                    Email = "neha.sharma@example.com",
                    PhoneN1 = "9876543211",
                    PhoneN2 = "9812345678",
                    DateOfBirth = new DateOnly(1998, 8, 21),
                    HomeAddress = "Pitampura, Delhi"
                },
                new()
                {
                    AadhaarId = "456789012345",
                    FirstName = "Amit",
                    LastName = "Gupta",
                    Email = "amit.gupta@example.com",
                    PhoneN1 = "9876543212",
                    DateOfBirth = new DateOnly(1989, 2, 5),
                    HomeAddress = "Shalimar Bagh, Delhi"
                },
                new()
                {
                    AadhaarId = "567890123456",
                    FirstName = "Priya",
                    LastName = "Malhotra",
                    Email = "priya.malhotra@example.com",
                    PhoneN1 = "9876543213",
                    DateOfBirth = new DateOnly(1993, 11, 17),
                    HomeAddress = "Model Town, Delhi"
                },
                new()
                {
                    AadhaarId = "678901234567",
                    FirstName = "Vikas",
                    LastName = "Kumar",
                    Email = "vikas.kumar@example.com",
                    PhoneN1 = "9876543214",
                    DateOfBirth = new DateOnly(1985, 6, 30),
                    HomeAddress = "Dwarka, Delhi"
                },
                new()
                {
                    AadhaarId = "789012345678",
                    FirstName = "Ananya",
                    LastName = "Singh",
                    Email = "ananya.singh@example.com",
                    PhoneN1 = "9876543215",
                    DateOfBirth = new DateOnly(2001, 1, 9),
                    HomeAddress = "Janakpuri, Delhi"
                },
                new()
                {
                    AadhaarId = "890123456789",
                    FirstName = "Ravi",
                    LastName = "Mehta",
                    Email = "ravi.mehta@example.com",
                    PhoneN1 = "9876543216",
                    DateOfBirth = new DateOnly(1978, 9, 25),
                    HomeAddress = "Punjabi Bagh, Delhi"
                },
                new()
                {
                    AadhaarId = "901234567890",
                    FirstName = "Kavita",
                    LastName = "Joshi",
                    Email = "kavita.joshi@example.com",
                    PhoneN1 = "9876543217",
                    DateOfBirth = new DateOnly(1990, 3, 14),
                    HomeAddress = "Ashok Vihar, Delhi"
                },
                new()
                {
                    AadhaarId = "123456789012",
                    FirstName = "Suresh",
                    LastName = "Chopra",
                    Email = "suresh.chopra@example.com",
                    PhoneN1 = "9876543218",
                    DateOfBirth = new DateOnly(1972, 12, 3),
                    HomeAddress = "Rajouri Garden, Delhi"
                },
                new()
                {
                    AadhaarId = "112233445566",
                    FirstName = "Simran",
                    LastName = "Kapoor",
                    Email = "simran.kapoor@example.com",
                    PhoneN1 = "9876543219",
                    DateOfBirth = new DateOnly(1997, 7, 19),
                    HomeAddress = "Vasant Kunj, Delhi"
                }
            };

            await context.Patients.AddRangeAsync(patients);
            await context.SaveChangesAsync();
        }

        var dentist = await userManager.FindByEmailAsync(
            "doctor@dentalclinic.com");

        if (dentist == null)
            return;

        var patientsList = await context.Patients
            .OrderBy(p => p.Id)
            .ToListAsync();

        if (await context.Appointments.AnyAsync())
            return;

        var appointments = new List<Appointment>
        {
            new()
            {
                PatientId = patientsList[0].Id,
                ScheduledDateTime = DateTime.Now.AddDays(1).Date.AddHours(10),
                DurationInMinutes = 30,
                AppointmentType = "Routine Checkup",
                ChiefComplaint = "Regular dental examination",
                Status = AppointmentStatus.Scheduled,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[1].Id,
                ScheduledDateTime = DateTime.Now.AddDays(1).Date.AddHours(11),
                DurationInMinutes = 60,
                AppointmentType = "Cleaning",
                ChiefComplaint = "Teeth cleaning and plaque buildup",
                Status = AppointmentStatus.Scheduled,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[2].Id,
                ScheduledDateTime = DateTime.Now.AddDays(2).Date.AddHours(10),
                DurationInMinutes = 90,
                AppointmentType = "Root Canal",
                ChiefComplaint = "Severe pain in upper right molar",
                Status = AppointmentStatus.Scheduled,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[3].Id,
                ScheduledDateTime = DateTime.Now.AddDays(-1).Date.AddHours(9),
                DurationInMinutes = 30,
                AppointmentType = "Consultation",
                ChiefComplaint = "Tooth sensitivity",
                Status = AppointmentStatus.Completed,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[4].Id,
                ScheduledDateTime = DateTime.Now.AddDays(-2).Date.AddHours(14),
                DurationInMinutes = 45,
                AppointmentType = "Cleaning",
                ChiefComplaint = "Routine cleaning",
                Status = AppointmentStatus.Completed,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[5].Id,
                ScheduledDateTime = DateTime.Now.AddDays(-3).Date.AddHours(11),
                DurationInMinutes = 60,
                AppointmentType = "Emergency",
                ChiefComplaint = "Severe toothache",
                Status = AppointmentStatus.Completed,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[6].Id,
                ScheduledDateTime = DateTime.Now.AddDays(3).Date.AddHours(15),
                DurationInMinutes = 30,
                AppointmentType = "Routine Checkup",
                ChiefComplaint = "Follow-up examination",
                Status = AppointmentStatus.Scheduled,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[7].Id,
                ScheduledDateTime = DateTime.Now.AddDays(-4).Date.AddHours(10),
                DurationInMinutes = 30,
                AppointmentType = "Consultation",
                ChiefComplaint = "Gum discomfort",
                Status = AppointmentStatus.NoShow,
                DentistId = dentist.Id
            },
            new()
            {
                PatientId = patientsList[8].Id,
                ScheduledDateTime = DateTime.Now.AddDays(-5).Date.AddHours(12),
                DurationInMinutes = 60,
                AppointmentType = "Root Canal",
                ChiefComplaint = "Persistent tooth pain",
                Status = AppointmentStatus.Cancelled,
                DentistId = dentist.Id
            }
        };

        await context.Appointments.AddRangeAsync(appointments);
        await context.SaveChangesAsync();
    }
}

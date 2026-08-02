namespace Web.ViewModels
{
    public class DashboardViewModel
    {
        // 1. KPI / Summary Cards
        public int TotalPatients { get; set; }
        public int AppointmentsTodayCount { get; set; }
        public int PendingAppointmentsCount { get; set; }
        public decimal TotalRevenueThisMonth { get; set; }

        // 2. Today's Schedule List
        public List<UpcomingAppointmentItemViewModel> TodayAppointments { get; set; } = new();

        // 3. Quick Alerts / Tasks (e.g., Pending Invoices or Low Stock)
        public int PendingInvoicesCount { get; set; }
        public List<RecentPatientItemViewModel> RecentPatients { get; set; } = new();
    }

    // Helper child DTO / ViewModel for Today's Appointments table/list
    public class UpcomingAppointmentItemViewModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentTime { get; set; }
        public string TreatmentType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // e.g., Confirmed, In-Progress, Completed
    }

    // Helper child DTO / ViewModel for Recently Registered Patients
    public class RecentPatientItemViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateRegistered { get; set; }
    }
}
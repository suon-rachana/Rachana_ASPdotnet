namespace AdminDashboard.Models
{
    public class StatCard
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public string Delta { get; set; }
        public bool IsPositive { get; set; }
    }

    public class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }   // Active | Pending | Suspended
        public DateTime JoinedOn { get; set; }
    }

    public class ActivityLog
    {
        public string Actor { get; set; }
        public string Action { get; set; }
        public DateTime When { get; set; }
    }

    // ViewModel passed to the Dashboard (Admin/Index)
    public class DashboardViewModel
    {
        public List<StatCard> Stats { get; set; }
        public List<ActivityLog> RecentActivity { get; set; }
        public List<int> EnrollmentsByMonth { get; set; }
        public List<string> MonthLabels { get; set; }
    }
}

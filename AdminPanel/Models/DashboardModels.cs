namespace AdminPanel.Models
{
    public class StatCard
    {
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Delta { get; set; } = string.Empty;
        public bool IsPositive { get; set; }
    }

    public class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;   // Active | Pending | Suspended
        public DateTime JoinedOn { get; set; }
    }

    public class ActivityLog
    {
        public string Actor { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime When { get; set; }
    }

    // ViewModel passed to the Dashboard (Admin/Index)
    public class DashboardViewModel
    {
        public List<StatCard> Stats { get; set; } = new();
        public List<ActivityLog> RecentActivity { get; set; } = new();
        public List<int> EnrollmentsByMonth { get; set; } = new();
        public List<string> MonthLabels { get; set; } = new();
    }
}

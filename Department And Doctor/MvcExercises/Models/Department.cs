namespace MvcExercises.Models
{
    // លំហាត់ 5.5 (DepartmentStaff)
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> StaffMembers { get; set; }
    }
}

namespace MvcExercises.Models
{
    // លំហាត់ 5.6 (DoctorSchedule)
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public List<string> AvailableDays { get; set; }
    }
}

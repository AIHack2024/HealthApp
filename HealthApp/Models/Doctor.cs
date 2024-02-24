namespace HealthApp.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public double Rating { get; set; }
    }
}

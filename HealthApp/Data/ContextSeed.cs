using HealthApp.Models;

namespace HealthApp.Data
{
    public class ContextSeed
    {
        public static async void SeedDoctors(ApplicationDbContext _context)
        {
            List<Doctor> doctors = new List<Doctor>
        {
            // Existing doctors
            new Doctor { Name = "Dr. Smith", Specialization = "Rheumatoid Arthritis", Rating = 4.5 },
            new Doctor { Name = "Dr. Johnson", Specialization = "Lupus", Rating = 4.7 },
            new Doctor { Name = "Dr. Williams", Specialization = "Psoriasis", Rating = 4.3 },

            // Added doctors based on CSV data
            new Doctor { Name = "Dr. Brown", Specialization = "Rheumatoid Arthritis", Rating = 4.6 },
            new Doctor { Name = "Dr. Davis", Specialization = "Sarcoidosis", Rating = 4.8 },
            new Doctor { Name = "Dr. Miller", Specialization = "Celiac Disease", Rating = 4.4 }
        };
            await _context.Doctors.AddRangeAsync(doctors);
        }
    }
}

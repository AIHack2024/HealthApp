using System.ComponentModel.DataAnnotations;

namespace HealthApp.Models
{
    public class AutoimmuneDiseaseEntry
    {
        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        public string Symptoms { get; set; }

        [Required]
        public string LaboratoryTests { get; set; }

        public string FamilyHistory { get; set; }

        public string PreviousDiagnosis { get; set; }

        public string? AutoimmuneDisease { get; set; }
    }
}

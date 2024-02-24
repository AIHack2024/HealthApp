//using System.ComponentModel.DataAnnotations;

//namespace HealthApp.Models
//{
//    using System.ComponentModel.DataAnnotations;

//    public class Patient
//    {
//        public int Id { get; set; }

//        [Required]
//        [Display(Name = "Gender")]
//        public string Gender { get; set; }

//        [Required]
//        [Display(Name = "Age")]
//        public int Age { get; set; }

//        [Required]
//        [Display(Name = "Symptoms")]
//        public string Symptoms { get; set; } // Consider parsing to a collection if needed

//        [Display(Name = "Systemic Manifestations")]
//        public bool SystemicManifestations { get; set; }

//        [Required]
//        [Display(Name = "Final Diagnosis")]
//        public string FinalDiagnosis { get; set; }

//        [Display(Name = "ANA")]
//        public string ANA { get; set; }

//        [Display(Name = "Anti-dsDNA")]
//        public string AntiDsDNA { get; set; }

//        [Display(Name = "RF")]
//        public string RF { get; set; }

//        [Display(Name = "CRP")]
//        public string CRP { get; set; }

//        [Display(Name = "WBC")]
//        public string WBC { get; set; }

//        // Example of optional fields with nullables
//        [Display(Name = "Blood Pressure Systolic")]
//        public int? BloodPressureSystolic { get; set; }

//        [Display(Name = "Blood Pressure Diastolic")]
//        public int? BloodPressureDiastolic { get; set; }

//        [Display(Name = "Heart Rate")]
//        public int? HeartRate { get; set; }
//        // Add additional fields as needed from your CSV data
//    }

//}

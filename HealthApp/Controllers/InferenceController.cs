using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using HealthApp.Models;
using HealthApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace HealthApp.Controllers
{
    public class InferenceController : Controller
    {
        private InferenceSession _session;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        static HttpClient client = new HttpClient();


        public InferenceController(InferenceSession session, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _session = session;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Score(PatientRecord data)
        {
            return View();
        }

        public class DataViewModel
        {
            public string disease { get; set; }
            public Doctor doctor { get; set; }
        }

        public async Task<IActionResult> GetData() 
        {
            //client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            IdentityUser user = await _userManager.GetUserAsync(User);


            PatientRecord record = await _context.Patients.Where(a => a.UserId== user.Id).FirstOrDefaultAsync();
           // string jsonData = JsonSerializer.Serialize(record);

            //var returnVal = await PostProductAsync(record);

            //Load sample data
            // Assuming 'record' is an instance of 'PatientRecord' that you want to use for prediction
            var sampleData = new MLModel1.ModelInput()
            {
                Gender = record.Gender,
                Age = (float)record.Age, // Casting int to float
                Symptoms = record.Symptoms,
                SystemicManifestations = record.SystemicManifestations,
                ANA = record.ANA,
                Anti_dsDNA = record.AntiDsDNA, // Adjust the property name if necessary
                RF = record.RF,
                CRP = record.CRP,
                WBC = record.WBC,
                RBC = record.RBC,
                Hemoglobin = record.Hemoglobin,
                Platelets = record.Platelets,
                ESR = record.ESR,
                FVC = record.FVC,
                FEV1 = record.FEV1,
                FEV1_FVC_Ratio = record.FEV1FVCRatio, // Adjust the property name if necessary
                Creatinine = record.Creatinine,
                GFR = record.GFR,
                C_Peptide = record.CPeptide, // Adjust the property name if necessary
                Autoantibodies = record.Autoantibodies,
                Fasting_Glucose = record.FastingGlucose, // Adjust the property name if necessary
                HbA1c = record.HbA1c,
                Anti_CCP = record.AntiCCP, // Adjust the property name if necessary
                Blood_Type = record.BloodType, // Adjust the property name if necessary
                Blood_Pressure = record.BloodPressure,
                Heart_Rate = record.HeartRate.HasValue ? (float)record.HeartRate.Value : float.NaN, // Handle nullable int with a default value
                Body_Temperature = record.BodyTemperature.HasValue ? record.BodyTemperature.Value : float.NaN, // Handle nullable float with a default value
                Oxygen_Saturation = record.OxygenSaturation,
                Current_Medications = record.CurrentMedications,
                X_ray_Findings = record.XRayFindings, // Adjust the property name if necessary
                MRI_Findings = record.MRIFindings, // Adjust the property name if necessary
                Echocardiogram_Results = record.EchocardiogramResults, // Adjust the property name if necessary
            };


            //Load model and predict output
            var result = MLModel1.Predict(sampleData);

            //result.

            DataViewModel vm = new()
            {
                disease = result.PredictedLabel,
                doctor = await GetDoctor(result.PredictedLabel)
            };

            return View(vm);

        }

        public async Task<Doctor> GetDoctor(string disease)
        {
            return await _context.Doctors.FirstOrDefaultAsync(a => a.Specialization == disease);
        }

        static async Task<string> PostProductAsync(PatientRecord record)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(record);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = client.PostAsync("posts", content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var postResponse = JsonSerializer.Deserialize<string>(responseContent, options);
                //Console.WriteLine("Post successful! ID: " + postResponse.Id);
                return postResponse;

            }
            else
            {
                return string.Empty;
                //Console.WriteLine("Error: " + response.StatusCode);
            }
        }
    }
}

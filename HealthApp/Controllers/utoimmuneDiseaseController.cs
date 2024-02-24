using HealthApp.Models;
using Microsoft.AspNetCore.Mvc;
using HealthApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthApp.Controllers
{
    public class AutoimmuneDiseaseController : Controller
    {
        // GET: AutoimmuneDisease/Create
        public IActionResult Create()
        {
            // Simulated data for select lists
            ViewBag.Gender = new SelectList(new List<string> { "Male", "Female", "Other" });
            ViewBag.FamilyHistory = new SelectList(new List<string> { "None", "RA", "SLE", "Psoriasis" });
            ViewBag.PreviousDiagnosis = new SelectList(new List<string> { "None", "Hypothyroidism", "Diabetes", "Hypertension" });
            ViewBag.AutoimmuneDisease = new SelectList(new List<string> { "None", "RA", "SLE", "Psoriasis" });

            return View();
        }

        // POST: AutoimmuneDisease/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AutoimmuneDiseaseEntry autoimmuneDiseaseEntry)
        {
            if (ModelState.IsValid)
            {
                // Save the data

                return RedirectToAction(nameof(Index));
            }

            // Repopulate SelectList if returning to form due to validation error
            ViewBag.Gender = new SelectList(new List<string> { "Male", "Female", "Other" }, autoimmuneDiseaseEntry.Gender);
            ViewBag.FamilyHistory = new SelectList(new List<string> { "None", "RA", "SLE", "Psoriasis" }, autoimmuneDiseaseEntry.FamilyHistory);
            ViewBag.PreviousDiagnosis = new SelectList(new List<string> { "None", "Hypothyroidism", "Diabetes", "Hypertension" }, autoimmuneDiseaseEntry.PreviousDiagnosis);
            ViewBag.AutoimmuneDisease = new SelectList(new List<string> { "None", "RA", "SLE", "Psoriasis" }, autoimmuneDiseaseEntry.AutoimmuneDisease);

            //Load sample data
            var sampleData = new MLModel.ModelInput()
            {
                Age = autoimmuneDiseaseEntry.Age,
                Gender = autoimmuneDiseaseEntry.Gender,
                Symptoms = autoimmuneDiseaseEntry.Symptoms,
                LaboratoryTests = autoimmuneDiseaseEntry.LaboratoryTests,
                FamilyHistory = autoimmuneDiseaseEntry.FamilyHistory,
                PreviousDiagnosis = autoimmuneDiseaseEntry.PreviousDiagnosis,
            };

            //Load model and predict output
            var result = MLModel.Predict(sampleData);


            return RedirectToAction(nameof(Result), new { ModelOutput = result.Score});


        }

        public IActionResult Result(float[] scores)
        {
            return View(scores);
        }
    }
}


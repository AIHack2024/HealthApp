using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthApp.Data;
using HealthApp.Models;

namespace HealthApp.Controllers
{
    public class PatientRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientRecords
        public async Task<IActionResult> Index()
        {
              return _context.Patients != null ? 
                          View(await _context.Patients.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Patients'  is null.");
        }

        // GET: PatientRecords/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patientRecord = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientRecord == null)
            {
                return NotFound();
            }

            return View(patientRecord);
        }

        // GET: PatientRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Gender,Age,Symptoms,SystemicManifestations,FinalDiagnosis,ANA,AntiDsDNA,RF,CRP,WBC,RBC,Hemoglobin,Platelets,ESR,FVC,FEV1,FEV1FVCRatio,Creatinine,GFR,CPeptide,Autoantibodies,FastingGlucose,HbA1c,AntiCCP,BloodType,BloodPressure,HeartRate,RespiratoryRate,BodyTemperature,OxygenSaturation,Cholesterol,ALT,AST,CurrentMedications,XRayFindings,MRIFindings,EchocardiogramResults")] PatientRecord patientRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientRecord);
        }

        // GET: PatientRecords/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patientRecord = await _context.Patients.FindAsync(id);
            if (patientRecord == null)
            {
                return NotFound();
            }
            return View(patientRecord);
        }

        // POST: PatientRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserId,Gender,Age,Symptoms,SystemicManifestations,FinalDiagnosis,ANA,AntiDsDNA,RF,CRP,WBC,RBC,Hemoglobin,Platelets,ESR,FVC,FEV1,FEV1FVCRatio,Creatinine,GFR,CPeptide,Autoantibodies,FastingGlucose,HbA1c,AntiCCP,BloodType,BloodPressure,HeartRate,RespiratoryRate,BodyTemperature,OxygenSaturation,Cholesterol,ALT,AST,CurrentMedications,XRayFindings,MRIFindings,EchocardiogramResults")] PatientRecord patientRecord)
        {
            if (id != patientRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientRecordExists(patientRecord.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patientRecord);
        }

        // GET: PatientRecords/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patientRecord = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientRecord == null)
            {
                return NotFound();
            }

            return View(patientRecord);
        }

        // POST: PatientRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Patients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Patients'  is null.");
            }
            var patientRecord = await _context.Patients.FindAsync(id);
            if (patientRecord != null)
            {
                _context.Patients.Remove(patientRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientRecordExists(string id)
        {
          return (_context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

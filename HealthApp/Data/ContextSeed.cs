using HealthApp.Models;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Plugins;
using System;
using HealthApp.Models;

namespace HealthApp.Data
{
    public class ContextSeed
    {
        public static async Task SeedDoctors(ApplicationDbContext _context)
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
            await _context.SaveChangesAsync();
        }

        public static async Task SeedUsers(IWebHostEnvironment env,UserManager<IdentityUser> _userManager, ApplicationDbContext _context)
        {
            var csvFilePath = Path.Combine(env.WebRootPath, "test.csv"); // Replace with your actual path and filename
            List<PatientRecord> userDataList = ParseCsv(csvFilePath);
            int i = 0;
            foreach (var userData in userDataList)
            {
                // Seed Default User
                var defaultUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "User" + i,
                    Email = i + "patient@email.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = false
                };
                if (_userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await _userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {
                        var result = await _userManager.CreateAsync(defaultUser, "Password123!");
                        userData.UserId = defaultUser.Id;
                        if (!result.Succeeded)
                        {
                            // Log the errors or throw an exception
                            foreach (var error in result.Errors)
                            {
                                Console.WriteLine(error.Description);
                            }
                        }
                        await _context.Patients.AddAsync(userData);
                        await _context.SaveChangesAsync();
                    }
                }
                i++;
            }
        }




            public static List<PatientRecord> ParseCsv(string filePath)
            {
                var records = new List<PatientRecord>();
                var lines = File.ReadAllLines(filePath).Skip(1); // Skip header line

                foreach (var line in lines)
                {
                    var values = line.Split(','); // This might not work correctly if your data contains commas. Consider a more robust CSV parser.

                    // Initialize nullable integers and floats
                    int nullableInt;
                    float nullableFloat;

                records.Add(new PatientRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Gender = values[0].Trim(),
                    Age = int.Parse(values[1].Trim()),
                    Symptoms = values[2].Trim(),
                        SystemicManifestations = bool.Parse(values[3].Trim()),
                    FinalDiagnosis = values[4].Trim(),
                    ANA = values[5].Trim(),
                    AntiDsDNA = values[6].Trim(),
                    RF = values[7].Trim(),
                    CRP = values[8].Trim(),
                    WBC = values[9].Trim(),
                    RBC = values[10].Trim(),
                    Hemoglobin = values[11].Trim(),
                    Platelets = values[12].Trim(),
                    ESR = values[13].Trim(),
                    FVC = values[14].Trim(),
                    FEV1 = values[15].Trim(),
                    FEV1FVCRatio = values[16].Trim(),
                    Creatinine = values[17].Trim(),
                    GFR = values[18].Trim(),
                    CPeptide = values[19].Trim(),
                    Autoantibodies = values[20].Trim(),
                    FastingGlucose = values[21].Trim(),
                    HbA1c = values[22].Trim(),
                    AntiCCP = values[23].Trim(),
                    BloodType = values[24].Trim(),
                    BloodPressure = values[25].Trim(),
                    HeartRate = int.Parse(values[26].Trim()),
                    RespiratoryRate = int.TryParse(values[27].Trim(), out nullableInt) ? nullableInt : null,
                    BodyTemperature = float.TryParse(values[28].Trim(), out nullableFloat) ? nullableFloat : null,
                    OxygenSaturation = values[29].Trim(),
                    Cholesterol = int.TryParse(values[30].Trim(), out nullableInt) ? nullableInt : null,
                    ALT = int.TryParse(values[31].Trim(), out nullableInt) ? nullableInt : null,
                    AST = int.TryParse(values[32].Trim(), out nullableInt) ? nullableInt : (int?)null,
                    CurrentMedications = values[33].Trim(),
                    XRayFindings = values[34].Trim(),
                    MRIFindings = values[35].Trim(),
                    EchocardiogramResults = values[36].Trim(),
                }) ;
                }

                return records;
            }

        }
    }

using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;

namespace HealthApp.Models
{
    public class PatientRecord
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string Symptoms { get; set; }
        public bool SystemicManifestations { get; set; }
        public string FinalDiagnosis { get; set; }
        public string ANA { get; set; }
        public string AntiDsDNA { get; set; }
        public string RF { get; set; }
        public string CRP { get; set; }
        public string WBC { get; set; }
        public string RBC { get; set; }
        public string Hemoglobin { get; set; }
        public string Platelets { get; set; }
        public string ESR { get; set; }
        public string FVC { get; set; }
        public string FEV1 { get; set; }
        public string FEV1FVCRatio { get; set; }
        public string Creatinine { get; set; }
        public string GFR { get; set; }
        public string CPeptide { get; set; }
        public string Autoantibodies { get; set; }
        public string FastingGlucose { get; set; }
        public string HbA1c { get; set; }
        public string AntiCCP { get; set; }
        public string BloodType { get; set; }
        public string BloodPressure { get; set; }
        public int? HeartRate { get; set; }
        public int? RespiratoryRate { get; set; }
        public float? BodyTemperature { get; set; }
        public string OxygenSaturation { get; set; }
        public int? Cholesterol { get; set; }
        public int? ALT { get; set; }
        public int? AST { get; set; }
        public string CurrentMedications { get; set; }
        public string XRayFindings { get; set; }
        public string MRIFindings { get; set; }
        public string EchocardiogramResults { get; set; }

     

    }
}

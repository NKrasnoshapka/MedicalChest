using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid MedicationId { get; set; }
        public Medication Medication { get; set; }

        public int Dosage { get; set; }

        public int DurationInDays { get; set; }

        public int DosesPerDay { get; set; }
    }
}

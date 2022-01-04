using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.DTOs
{
    public class PrescriptionDTO
    {
        public Guid MedicationId { get; set; }

        public string Dosage { get; set; }

        public int DurationInDays { get; set; }

        public int DosesPerDay { get; set; }
    }
}

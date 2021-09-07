using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.Models
{
    public class Prescription
    {
        public Guid Id { get; set; }

        public Guid MedicationId { get; set; }
        public Medication Medication { get; set; }

        public string Dosage { get; set; }

        public int DurationInDays { get; set; }

        public int DosesPerDay { get; set; }

        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
    }
}

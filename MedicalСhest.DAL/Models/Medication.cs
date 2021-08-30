using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.Models
{
    public class Medication
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool NeedPrescriptions { get; set; }

        public DrugCategory DrugCategory { get; set; }

        public DosageForm DosageForm { get; set; }

        public string Dosage { get; set; }

        public string Description { get; set; }

        public string BrandName { get; set; }
    }
}

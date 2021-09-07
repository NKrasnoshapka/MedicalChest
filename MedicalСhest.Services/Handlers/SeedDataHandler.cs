using MediatR;
using MedicalСhest.DAL;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.Services.Handlers
{
    public class SeedDataHandler : IRequestHandler<SeedDataCommand, Unit>
    {
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public SeedDataHandler(MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
        }

        public async Task<Unit> Handle(SeedDataCommand command, CancellationToken cancellationToken)
        {
            await SeedData();
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }

        private async Task SeedData()
        {
            List<Medication> medications = new List<Medication>()
            {
                new Medication
                {   Name = "Aspirin",
                    BrandName = "Bayer Buffered",
                    Description = "Aspirin is rapidly metabolized to salicylate after ingestion, so most studies have measured salicylate levels in breastmilk after aspirin administration to the mother; however, some studies have not measured salicylate metabolites in breastmilk that may be hydrolyzed in the infant's gut and absorbed as salicylate.",
                    DosageForm = DosageForm.Tablet,
                    Dosage = "325mg",
                    DrugCategory = DrugCategory.AntiInflammatories,
                    NeedLicense = false
                },

                new Medication
                {   Name = "Baclofen",
                    BrandName = "Chandra Bhagat",
                    Description = "Indicated for spasticity resulting from multiple sclerosis, particularly for the relief of flexor spasms and concomitant pain, clonus, and muscular rigidity.",
                    DosageForm = DosageForm.Tablet,
                    Dosage = "10mg",
                    DrugCategory = DrugCategory.MuscleRelaxants,
                    NeedLicense = false
                },

                new Medication
                {   Name = "Sertraline",
                    BrandName = "Pfizer",
                    Description = "Sertraline, sold under the brand name Zoloft among others, is an antidepressant of the selective serotonin reuptake inhibitor (SSRI) class. The efficacy of sertraline for depression is similar to that of other antidepressants, and the differences are mostly confined to side effects.",
                    DosageForm = DosageForm.Capsule,
                    Dosage = "25mg",
                    DrugCategory = DrugCategory.Antidepressants,
                    NeedLicense = false
                }
            };

            await _medicalСhestDBContext.Medications.AddRangeAsync(medications);
        }
    }
}

using FluentValidation;
using MedicalСhest.DAL;
using MedicalСhest.Helpers.Extensions;
using MedicalСhest.Messages.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalСhest.Services.Validators
{
    public class AssignDoctorValidator : AbstractValidator<AssignDoctorCommand>
    {
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public AssignDoctorValidator(MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;

            RuleFor(x => x)
           .Must(a => IsDoctorExist(a.DoctorId).Result)
                  .WithMessage("This Doctor Id is not exist")
           .Must(a => IsPatientExist(a.PatientId).Result)
             .WithMessage("This Patient Id is not exist")
           .Must(a => CheckSpecialisation(a.DoctorId, a.PatientId).Result)
           .WithMessage("The Doctor with the same specialisation has already been assign");
        }

        public async Task<bool> CheckSpecialisation(Guid doctorId, Guid patientId)
        {
            var doctor = await _medicalСhestDBContext.Doctors.FindAsync(doctorId);
            var patient = await _medicalСhestDBContext.Patients.Include(x => x.Doctors).FirstOrDefaultAsync(p => p.Id == patientId);

            if (!patient.Doctors.Any())
                return true;

            foreach (var assignedDoctor in patient.Doctors)
            {
                if (assignedDoctor.Specialisation == doctor.Specialisation)
                    return false;
            }

            return true;
        }

        public async Task<bool> IsDoctorExist(Guid doctorId)
        {
            var doctor = await _medicalСhestDBContext.Doctors.FindAsync(doctorId);
            return doctor != null;
        }

        public async Task<bool> IsPatientExist(Guid patientId)
        {
            var patient = await _medicalСhestDBContext.Patients.FindAsync(patientId);
            return patient != null;
        }
    }
}

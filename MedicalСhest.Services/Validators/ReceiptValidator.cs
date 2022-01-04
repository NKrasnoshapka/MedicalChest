using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Services.Validators
{
    class ReceiptValidator
    {
        public DoctorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");

            RuleFor(x => x.Specialisation)
                .NotEmpty()
                .WithMessage("Specialisation is required")
                .IsInEnum();

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required")
                .Must(BeValidDateOfBirth)
                .WithMessage("Invalid date of birth");
        }

        public async Task<bool> CheckIsDoctorNotAssigned(Guid doctorId, Guid patientId)
        {

        }
    }
}

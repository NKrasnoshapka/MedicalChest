using FluentValidation;
using MedicalСhest.Helpers.Extensions;
using MedicalСhest.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Services.Validators
{
    public class PatientValidator : AbstractValidator<AddNewPatientCommand>
    {
        public PatientValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email is in wrong format.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required")
                .Must(BeValidDateOfBirth)
                .WithMessage("Invalid date of birth");
        }

        private bool BeValidDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.CalculateAge() > 5;
        }
    }
}

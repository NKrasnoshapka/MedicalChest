﻿using FluentValidation;
using MedicalСhest.Helpers.Extensions;
using MedicalСhest.Messages.Commands;
using System;

namespace MedicalСhest.Services.Validators
{
    public class DoctorValidator : AbstractValidator<AddNewDoctorCommand>
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

        private bool BeValidDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.CalculateAge() > 18;
        }
    }
}

using FluentValidation;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.Validators
{
    public class DoctorValidator : AbstractValidator<AddNewDoctorCommand>
    {
        public DoctorValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Specialisation).NotEmpty();
        }
    }
}

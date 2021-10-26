using FluentValidation;
using MedicalСhest.DAL.IdentityModels;
using MedicalСhest.Messages.Commands;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedicalСhest.Services.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly UserManager<MedicalChestUser> _userManager;

        public RegisterValidator(UserManager<MedicalChestUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username name is required")
                .Must(x => IsUserExistAsync(x).Result);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email is in wrong format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password of birth is required")
                .Length(5, 15)
                .Must(x => HasValidPassword(x));
        }

        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }

        private async Task<bool> IsUserExistAsync(string userName)
        {
            var userExists = await _userManager.FindByNameAsync(userName);
            return userExists != null;
        }

    }
}

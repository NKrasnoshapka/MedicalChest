using MediatR;
using MedicalСhest.DAL;
using MedicalСhest.DAL.IdentityModels;
using MedicalСhest.Messages.Commands;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.Services
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly UserManager<MedicalChestUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IConfiguration _configuration;

        public RegisterUserHandler(UserManager<MedicalChestUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }



        public async Task<IdentityResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(command.Username);

            MedicalChestUser user = new MedicalChestUser()
            {
                Email = command.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = command.Username
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            //if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            //if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (command.IsAdmin)
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            else
                await _userManager.AddToRoleAsync(user, UserRoles.User);

            return result;
        }
    }
}

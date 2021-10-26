using MediatR;
using MedicalСhest.DAL.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.Services.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQueries, JwtToken>
    {
        private readonly UserManager<MedicalChestUser> _userManager;

        private readonly IConfiguration _configuration;

        public LoginHandler(UserManager<MedicalChestUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<JwtToken> Handle(LoginQueries query, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(query.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, query.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new JwtToken
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationTime = token.ValidTo
                };
            }
            else
            {
                return new JwtToken();
            }
        }
    }
}

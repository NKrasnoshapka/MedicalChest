using MediatR;
using MedicalСhest.DAL.IdentityModels;
using MedicalСhest.Messages.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly UserManager<MedicalChestUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginQueries query, CancellationToken token = default)
        {
            var logingResult = await _mediator.Send(query, token);

            if (logingResult.Token != null)
                return Ok(logingResult);
            else
                return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken token = default)
        {
            var logingResult = await _mediator.Send(command, token);

            if (logingResult.Succeeded)
                return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }
    }
}

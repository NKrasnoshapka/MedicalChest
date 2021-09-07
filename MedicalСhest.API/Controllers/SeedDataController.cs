using MediatR;
using MedicalСhest.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.API.Controllers
{
    [Route("api/seeddata")]
    [ApiController]
    public class SeedDataController : Controller
    {
        private readonly IMediator _mediator;

        public SeedDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SeedData(CancellationToken token = default)
        {
            await _mediator.Send(new SeedDataCommand(), token);
            return Ok();
        }
    }
}

using AutoMapper;
using MediatR;
using MedicalСhest.Messages.Commands;
using MedicalСhest.Messages.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost("doctors")]
        public async Task<IActionResult> AddNewDoctor([FromBody] AddNewDoctorCommand newDoctor, CancellationToken token = default)
        {
            await _mediator.Send(newDoctor, token);
            return Ok();
        }

        [HttpGet("test")]
        public IActionResult TestGet()
        {
            return Ok("Sucsess");
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> GetAllDoctors(CancellationToken token = default)
        {
            var allDoctors = await _mediator.Send(new AllDoctorsQueries(), token);
            return Ok(allDoctors);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetDoctorById(string doctorId, CancellationToken token = default)
        {
            var booksByIdQuery = new DoctorByIdQueries { Id = Guid.Parse(doctorId) };
            var doctor = await _mediator.Send(booksByIdQuery, token);
            return Ok(doctor);
        }
    }
}

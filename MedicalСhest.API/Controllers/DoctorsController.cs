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
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDoctor([FromBody] AddNewDoctorCommand newDoctor, CancellationToken token = default)
        {
            await _mediator.Send(newDoctor, token);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors(CancellationToken token = default)
        {
            var allDoctors = await _mediator.Send(new AllDoctorsQueries(), token);
            return Ok(allDoctors);
        }

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetDoctorById(string doctorId, CancellationToken token = default)
        {
            var booksByIdQuery = new DoctorByIdQueries { Id = Guid.Parse(doctorId) };
            var doctor = await _mediator.Send(booksByIdQuery, token);
            return Ok(doctor);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorCommand doctor, CancellationToken token = default)
        {
            await _mediator.Send(doctor, token);
            return Ok();
        }
    }
}

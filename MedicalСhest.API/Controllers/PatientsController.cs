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
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : Controller
    {
        private readonly IMediator _mediator;
        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPatinet([FromBody] AddNewPatientCommand newPatient, CancellationToken token = default)
        {
            await _mediator.Send(newPatient, token);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatinets(CancellationToken token = default)
        {
            var patients = await _mediator.Send(new AllPatientsQueries(), token);
            return Ok(patients);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatinetById(string patientId, CancellationToken token = default)
        {
            var patientByIdQuery = new PatientByIdQueries { Id = Guid.Parse(patientId) };
            var patient = await _mediator.Send(patientByIdQuery, token);
            return Ok(patient);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientCommand patient, CancellationToken token = default)
        {
            await _mediator.Send(patient, token);
            return Ok();
        }
    }
}

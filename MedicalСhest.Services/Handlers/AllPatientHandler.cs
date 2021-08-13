using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicalСhest.DAL;
using MedicalСhest.DAL.DTOs;

namespace MedicalСhest.Services.Handlers
{
    public class AllPatientHandler : IRequestHandler<AllPatientsQueries, IEnumerable<PatinetDTO>>
    {
        private readonly IMapper _mapper;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public AllPatientHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatinetDTO>> Handle(AllPatientsQueries query, CancellationToken cancellationToken)
        {
            var patients = await _medicalСhestDBContext.Patients.ToListAsync();
            return _mapper.Map<List<Patient>, List<PatinetDTO>>(patients);
        }
    }
}

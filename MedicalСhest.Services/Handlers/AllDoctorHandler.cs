using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Queries;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicalСhest.DAL;
using MedicalСhest.DAL.DTOs;

namespace MedicalСhest.Services.Handlers
{
    public class AllDoctorHandler : IRequestHandler<AllDoctorsQueries, IEnumerable<DoctorDTO>>
    {
        private readonly IMapper _mapper;
        private readonly DbSet<Doctor> _dbSet;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public AllDoctorHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _dbSet = medicalСhestDBContext.Set<Doctor>();
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDTO>> Handle(AllDoctorsQueries query, CancellationToken cancellationToken)
        {
            var doctors = await _dbSet.ToListAsync();
            return _mapper.Map<List<Doctor>, List<DoctorDTO>>(doctors);
        }
    }
}

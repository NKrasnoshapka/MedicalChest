using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Queries;
using System.Collections.Generic;
using System;
using MedicalСhest.Helpers.Helpers;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicalСhest.DAL;
using MedicalСhest.DAL.DTOs;

namespace MedicalСhest.Services.Handlers
{
    public class DoctorByIdHendler : IRequestHandler<DoctorByIdQueries, DoctorDTO>
    {
        private readonly IMapper _mapper;
        private readonly DbSet<Doctor> _dbSet;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public DoctorByIdHendler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _dbSet = medicalСhestDBContext.Set<Doctor>();
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<DoctorDTO> Handle(DoctorByIdQueries query, CancellationToken cancellationToken)
        {
            var doctor = await _dbSet.FindAsync(query.Id);
            return _mapper.Map<Doctor, DoctorDTO>(doctor);
        }
    }
}

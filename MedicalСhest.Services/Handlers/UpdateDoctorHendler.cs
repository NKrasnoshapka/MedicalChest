using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Commands;
using System.Collections.Generic;
using System;
using MedicalСhest.Helpers.Helpers;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicalСhest.DAL;

namespace MedicalСhest.Services.Handlers
{
    public class UpdateDoctorHendler : IRequestHandler<UpdateDoctorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly DbSet<Doctor> _dbSet;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public UpdateDoctorHendler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _dbSet = medicalСhestDBContext.Set<Doctor>();
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            _dbSet.Update(_mapper.Map<Doctor>(command));
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Commands;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicalСhest.DAL;

namespace MedicalСhest.Services.Handlers
{
    public class AddNewDoctorHandler : IRequestHandler<AddNewDoctorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public AddNewDoctorHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddNewDoctorCommand command, CancellationToken cancellationToken)
        {
            await _medicalСhestDBContext.Doctors.AddAsync(_mapper.Map<Doctor>(command));
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

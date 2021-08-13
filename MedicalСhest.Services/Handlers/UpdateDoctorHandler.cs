﻿using MediatR;
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
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public UpdateDoctorHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            _medicalСhestDBContext.Doctors.Update(_mapper.Map<Doctor>(command));
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

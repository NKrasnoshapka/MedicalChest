using AutoMapper;
using MediatR;
using MedicalСhest.DAL;
using MedicalСhest.DAL.DTOs;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.Services.Handlers
{
    public class AddReceiptHandler : IRequestHandler<AddReceiptCommand, Unit>
    {
        private readonly MedicalСhestDBContext _medicalСhestDBContext;
        private readonly IMapper _mapper;

        public AddReceiptHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddReceiptCommand command, CancellationToken cancellationToken)
        {
            Receipt receipt = new Receipt()
            {
                Id = Guid.NewGuid(),
                DoctorId = command.DoctorId,
                PatientId = command.PatientId,
            };

            var prescriptions = new List<Prescription>();

            foreach(PrescriptionDTO prescriptionsDTO in command.prescriptions)
            {
                var prescription = _mapper.Map<Prescription>(prescriptionsDTO);
                prescription.ReceiptId = receipt.Id;

                prescriptions.Add(prescription);
            }

            await _medicalСhestDBContext.Prescriptions.AddRangeAsync(prescriptions);
            await _medicalСhestDBContext.Receipts.AddAsync(receipt);
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

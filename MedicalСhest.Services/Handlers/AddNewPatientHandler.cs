using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Commands;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MedicalСhest.DAL;

namespace MedicalСhest.Services.Handlers
{
    public class AddNewPatientHandler : IRequestHandler<AddNewPatientCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public AddNewPatientHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddNewPatientCommand command, CancellationToken cancellationToken)
        {
            await _medicalСhestDBContext.Patients.AddAsync(_mapper.Map<Patient>(command));
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

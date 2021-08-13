using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Commands;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MedicalСhest.DAL;

namespace MedicalСhest.Services.Handlers
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public UpdatePatientHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            _medicalСhestDBContext.Patients.Update(_mapper.Map<Patient>(command));
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

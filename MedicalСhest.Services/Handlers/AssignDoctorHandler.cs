using MediatR;
using MedicalСhest.DAL;
using MedicalСhest.Messages.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalСhest.Services.Handlers
{
    public class AssignDoctorHandler : IRequestHandler<AssignDoctorCommand, Unit>
    {
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public AssignDoctorHandler(MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
        }

        public async Task<Unit> Handle(AssignDoctorCommand command, CancellationToken cancellationToken)
        { 
            var patient = await _medicalСhestDBContext.Patients.FindAsync(command.PatientId);
            var doctor = await _medicalСhestDBContext.Doctors.FindAsync(command.DoctorId);

            patient.Doctors.Add(doctor);
            doctor.Patients.Add(patient);

            _medicalСhestDBContext.Patients.Update(patient);
            _medicalСhestDBContext.Doctors.Update(doctor);
            await _medicalСhestDBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

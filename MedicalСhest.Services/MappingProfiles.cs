using AutoMapper;
using MedicalСhest.DAL.DTOs;
using MedicalСhest.DAL.Models;
using MedicalСhest.Helpers.Extensions;
using MedicalСhest.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            AddNewDoctorMapping();
            DoctorMapping();
            UpdateDoctorMapping();
            AddNewPatinetMapping();
            PatientMapping();
            UpdatePatientMapping();
            AddReceiptMapping();
        }

        public void AddNewDoctorMapping()
        {
            CreateMap<AddNewDoctorCommand, Doctor>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName)) 
                .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
                .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
                .ForMember(dest => dest.DateOfBirth, source => source.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Organisation, source => source.MapFrom(src => src.Organisation))
                .ForMember(dest => dest.Email, source => source.MapFrom(src => "medicalChest@gmail.com"))
                .ForMember(dest => dest.Age, source => source.MapFrom(src => src.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.Specialisation, source => source.MapFrom(src => src.Specialisation));
        }

        public void DoctorMapping()
        {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Organisation, source => source.MapFrom(src => src.Organisation))
                .ForMember(dest => dest.Age, source => source.MapFrom(src => src.Age))
                .ForMember(dest => dest.Specialisation, source => source.MapFrom(src => src.Specialisation));
        }

        public void UpdateDoctorMapping()
        {
            CreateMap<UpdateDoctorCommand, Doctor>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
                .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
                .ForMember(dest => dest.DateOfBirth, source => source.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Organisation, source => source.MapFrom(src => src.Organisation))
                .ForMember(dest => dest.Email, source => source.MapFrom(src => "medicalChest@gmail.com"))
                .ForMember(dest => dest.Age, source => source.MapFrom(src => src.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.Specialisation, source => source.MapFrom(src => src.Specialisation));
        }

        public void AddNewPatinetMapping()
        {
            CreateMap<AddNewPatientCommand, Patient>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
                .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
                .ForMember(dest => dest.DateOfBirth, source => source.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email))
                .ForMember(dest => dest.Age, source => source.MapFrom(src => src.DateOfBirth.CalculateAge()));
        }

        public void PatientMapping()
        {
            CreateMap<Patient, PatinetDTO>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Age, source => source.MapFrom(src => src.Age))
                .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
                .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email));
        }

        public void UpdatePatientMapping()
        {
            CreateMap<UpdatePatientCommand, Patient>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, source => source.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
                .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email))
                .ForMember(dest => dest.Age, source => source.MapFrom(src => src.DateOfBirth.CalculateAge()));
        }

        public void AddReceiptMapping()
        {
            CreateMap<PrescriptionDTO, Prescription>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.MedicationId, source => source.MapFrom(src => src.MedicationId))
                .ForMember(dest => dest.Dosage, source => source.MapFrom(src => src.Dosage))
                .ForMember(dest => dest.DosesPerDay, source => source.MapFrom(src => src.DosesPerDay));
        }
    }
}

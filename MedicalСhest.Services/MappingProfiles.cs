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
        }

        public void AddNewDoctorMapping()
        {
            CreateMap<AddNewDoctorCommand, Doctor>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.FirstName, source => source.UseDestinationValue()) //TODO: MapFrom
                .ForMember(dest => dest.LastName, source => source.UseDestinationValue())
                .ForMember(dest => dest.City, source => source.UseDestinationValue())
                .ForMember(dest => dest.DateOfBirth, source => source.UseDestinationValue())
                .ForMember(dest => dest.Organisation, source => source.UseDestinationValue())
                .ForMember(dest => dest.Email, source => source.MapFrom(src => "medicalChest@gmail.com"))
                .ForMember(dest => dest.Age, source => source.MapFrom(src => src.DateOfBirth.CalculateAge()));
        }

        public void DoctorMapping()
        {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.Id, source => source.UseDestinationValue())
                .ForMember(dest => dest.FirstName, source => source.UseDestinationValue())
                .ForMember(dest => dest.LastName, source => source.UseDestinationValue())
                .ForMember(dest => dest.Organisation, source => source.UseDestinationValue())
                .ForMember(dest => dest.Age, source => source.UseDestinationValue());
        }

        public void UpdateDoctorMapping()
        {
            CreateMap<UpdateDoctorCommand, Doctor>()
                .ForMember(dest => dest.Id, source => source.UseDestinationValue())
                .ForMember(dest => dest.FirstName, source => source.UseDestinationValue())
                .ForMember(dest => dest.LastName, source => source.UseDestinationValue())
                .ForMember(dest => dest.City, source => source.UseDestinationValue())
                .ForMember(dest => dest.DateOfBirth, source => source.UseDestinationValue())
                .ForMember(dest => dest.Organisation, source => source.UseDestinationValue());
        }
    }
}

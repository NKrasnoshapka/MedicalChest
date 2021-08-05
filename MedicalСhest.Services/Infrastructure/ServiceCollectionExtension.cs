using MediatR;
using MedicalСhest.DAL.DTOs;
using MedicalСhest.Messages.Commands;
using MedicalСhest.Messages.Queries;
using MedicalСhest.Services.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MedicalСhest.Services.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtension
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.For<AddNewDoctorCommand, Unit>()
                .AddHandler<AddNewDoctorHandler>()
                .Scoped();

            services.For<AllDoctorsQueries, IEnumerable<DoctorDTO>>()
                .AddHandler<AllDoctorHandler>()
                .Scoped();

            services.For<DoctorByIdQueries, DoctorDTO>()
                .AddHandler<DoctorByIdHandler>()
                .Scoped();

            services.For<UpdateDoctorCommand, Unit>()
                .AddHandler<UpdateDoctorHandler>()
                .Scoped();
        }

        private static ServiceRegistrationOptions<TRequest, TResponse> For<TRequest, TResponse>(this IServiceCollection services)
                where TRequest : IRequest<TResponse>
        {
            return new ServiceRegistrationOptions<TRequest, TResponse>(services);
        }
    }
}

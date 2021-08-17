using FluentValidation;
using Library.Services.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MedicalСhest.Services.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class ServiceRegistrationOptions<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IServiceCollection _services;

        private readonly List<Type> _typesToRegister = new List<Type>();
        private readonly List<Func<IServiceProvider, IRequestHandler<TRequest, TResponse>, IRequestHandler<TRequest, TResponse>>> _handlers = new List<Func<IServiceProvider, IRequestHandler<TRequest, TResponse>, IRequestHandler<TRequest, TResponse>>>();
        private Func<IServiceProvider, IRequestHandler<TRequest, TResponse>> _handlerFactory;

        public ServiceRegistrationOptions(IServiceCollection services)
        {
            _services = services;
        }

        public ServiceRegistrationOptions<TRequest, TResponse> WithValidation<TValidator>()
                where TValidator : class, IValidator<TRequest>
        {
            _typesToRegister.Add(typeof(TValidator));

            _handlers.Add((provider, inner) => new ValidationRequestHandler<TRequest, TResponse>(provider.GetService<TValidator>(), inner));

            return this;
        }

        public ServiceRegistrationOptions<TRequest, TResponse> AddHandler<THandler>()
            where THandler : class, IRequestHandler<TRequest, TResponse>
        {
            _typesToRegister.Add(typeof(THandler));

            _handlerFactory = provider => provider.GetService<THandler>();

            return this;
        }

        public ServiceRegistrationOptions<TRequest, TResponse> AddHandler<THandler>(Func<IServiceProvider, THandler> func)
            where THandler : class, IRequestHandler<TRequest, TResponse>
        {
            _typesToRegister.Add(typeof(THandler));

            _handlerFactory = func;

            return this;
        }

        public void Scoped()
        {
            foreach (var type in _typesToRegister)
            {
                _services.AddScoped(type);
            }

            _services.AddScoped(GetResolver());
        }

        public void Transient()
        {
            foreach (var type in _typesToRegister)
            {
                _services.AddTransient(type);
            }

            _services.AddTransient(GetResolver());
        }

        public void Singleton()
        {
            foreach (var type in _typesToRegister)
            {
                _services.AddSingleton(type);
            }

            _services.AddSingleton(GetResolver());
        }

        private Func<IServiceProvider, IRequestHandler<TRequest, TResponse>> GetResolver()
        {
            var result = _handlerFactory;

            _handlers.Reverse();
            foreach (var handler in _handlers)
            {
                var closure = result;
                result = c => handler(c, closure(c));
            }

            return result;
        }
    }
}

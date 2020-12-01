using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.DIConfiguration
{
    public static class ServiceCollectionServiceExtensions
    {
        public static void AddConfigurationBindings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfigurationBindings(new BindingResolver().GetDefinitions(configuration));
        }

        public static void AddConfigurationBindings(this IServiceCollection services, IEnumerable<BindingDefinition> bindingDefinitions)
        {
            foreach (var definition in bindingDefinitions)
            {
                RegisterService(services, definition);
            }
        }

        private static void RegisterService(IServiceCollection services, BindingDefinition bindingDefinition)
        {
            switch (bindingDefinition.Scope)
            {
                case BindingScope.Scoped:
                    services.AddScoped(bindingDefinition.ServiceType, bindingDefinition.ImplementationType);
                    break;

                case BindingScope.Singleton:
                    services.AddSingleton(bindingDefinition.ServiceType, bindingDefinition.ImplementationType);
                    break;

                case BindingScope.Transient:
                    services.AddTransient(bindingDefinition.ServiceType, bindingDefinition.ImplementationType);
                    break;

                default:
                    throw new ArgumentException();
            }
        }
    }
}

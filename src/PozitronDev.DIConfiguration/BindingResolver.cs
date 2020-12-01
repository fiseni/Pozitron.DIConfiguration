using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.DIConfiguration
{
    public class BindingResolver
    {
        public IEnumerable<BindingDefinition> GetDefinitions(IConfiguration configuration)
        {
            var bindingSection = configuration.GetSection("Bindings");
            var bindingDefinitions = new List<BindingDefinition>();

            foreach (var section in bindingSection.GetChildren())
            {
                bindingDefinitions.Add(new BindingDefinition()
                {
                    ServiceType = Type.GetType(section.GetSection("service").Value, true),
                    ImplementationType = Type.GetType(section.GetSection("implementation").Value, true),
                    Scope = BindingScopeMapper.GetScope(section.GetSection("scope").Value)
                });
            }

            return bindingDefinitions;
        }
    }
}

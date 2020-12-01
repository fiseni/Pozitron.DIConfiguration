using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.DIConfiguration
{
    public class BindingDefinition
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public BindingScope Scope { get; }

        public BindingDefinition(Type serviceType, Type implementationType, BindingScope scope)
        {
            this.ServiceType = serviceType;
            this.ImplementationType = implementationType;
            this.Scope = scope;
        }
    }
}

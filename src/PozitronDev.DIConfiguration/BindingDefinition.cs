using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.DIConfiguration
{
    public class BindingDefinition
    {
        public Type ServiceType { get; set; }
        public Type ImplementationType { get; set; }
        public BindingScope Scope { get; set; }
    }
}

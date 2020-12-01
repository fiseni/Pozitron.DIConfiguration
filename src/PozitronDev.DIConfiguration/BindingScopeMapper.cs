using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.DIConfiguration
{
    public static class BindingScopeMapper
    {
        public static BindingScope GetScope(string scope)
        {
            if (scope.Equals("singleton", StringComparison.InvariantCultureIgnoreCase))
            {
                return BindingScope.Singleton;
            }
            else if (scope.Equals("scoped", StringComparison.InvariantCultureIgnoreCase))
            {
                return BindingScope.Scoped;
            }
            else if (scope.Equals("transient", StringComparison.InvariantCultureIgnoreCase))
            {
                return BindingScope.Transient;
            }

            throw new NotSupportedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLibrary
{
    public class SimpleService : ISimpleService
    {
        public string GetMessage()
        {
            return $"Message from {nameof(SimpleService)}.";
        }
    }
}

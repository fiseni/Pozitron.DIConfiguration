using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLibrary
{
    public class GenericService<T> : IGenericService<T>
    {
        public string GetMessage()
        {
            return $"Message from {nameof(GenericService<T>)}.";
        }
    }
}

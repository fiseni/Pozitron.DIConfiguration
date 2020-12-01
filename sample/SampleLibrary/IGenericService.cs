using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLibrary
{
    public interface IGenericService<T>
    {
        string GetMessage();
    }
}

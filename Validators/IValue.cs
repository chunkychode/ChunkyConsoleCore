using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    public interface IValue<T>
    {
        T Value { get; }
    }
}

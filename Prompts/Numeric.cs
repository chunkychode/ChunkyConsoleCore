using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Prompts
{
    public class Numeric<T> : PromptItem where T : struct, IConvertible, IComparable<T>
    {
        public Numeric()
        {
            Validator = new Validators.Numeric<T>();
        }
    }

    public class Int : Numeric<int> { }
    public class Double : Numeric<double> { }
    public class Long : Numeric<long> { }
    public class Decimal : Numeric<decimal> { }
    public class Float : Numeric<float> { }
}

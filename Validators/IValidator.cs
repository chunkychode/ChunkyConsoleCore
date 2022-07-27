using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    public interface IValidator
    {
        bool Validate(string val);

        string ErrorMessage { get; }

        Action<object> Assignment { get; set; }
    }
}

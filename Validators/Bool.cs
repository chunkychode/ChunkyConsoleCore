using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChunkyConsoleCore.Validators
{
    public class Bool : BaseValidator<bool>
    {
        public Bool() : base("Value must be [true | t | false | f]") { }

        public Bool(string errorMessage) : base(errorMessage) { }

        public override bool Validate(string val)
        {
            val = string.Compare(val, "true", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(val, "t", StringComparison.OrdinalIgnoreCase) == 0 ? bool.TrueString : val;
            val = string.Compare(val, "false", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(val, "f", StringComparison.OrdinalIgnoreCase) == 0 ? bool.FalseString : val;

            bool dt;
            if (bool.TryParse(val, out dt))
            {
                Assignment(dt);
                //Value = dt;
                return true;
            }
            return false;
        }
    }
}

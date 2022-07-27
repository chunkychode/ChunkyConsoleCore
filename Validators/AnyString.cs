using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    class AnyString : BaseValidator<string>
    {
        public AnyString() : this("value may be anything") { }
        public AnyString(string errorMessage) : base(errorMessage) { }
        public override bool Validate(string val)
        {
            Assignment(val);
            return true;
        }
    }
}

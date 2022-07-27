using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChunkyConsoleCore.Validators
{
    public class DateTime : BaseValidator<System.DateTime>
    {
        public DateTime() : base("Value must be a valid Date Time format") { }

        public DateTime(string errorMessage) : base(errorMessage) { }

        public override bool Validate(string val)
        {
            System.DateTime dt;
            if (System.DateTime.TryParse(val, out dt))
            {
                Assignment(dt);
                //Value = dt;
                return true;
            }
            return false;
        }
    }



}
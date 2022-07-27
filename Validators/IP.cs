using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    public class IP : BaseValidator<System.Net.IPAddress>
    {
        public IP() : base("Value must be a valid IPAddress") { }
        public IP(string errorMessage) : base(errorMessage) { }
        public override bool Validate(string val)
        {
            System.Net.IPAddress ip;
            if (System.Net.IPAddress.TryParse(val, out ip))
            {
                //Value = ip;
                Assignment(ip);
                return true;
            }
            return false;

        }
    }
}

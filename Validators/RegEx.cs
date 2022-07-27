using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    public class RegEx : NonBlankString
    {
        public RegEx(string pattern) { Pattern = pattern; }
        public RegEx() { }
        public string Pattern { get; set; }

        public const string EMAIL = @"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$";
        public const string PHONENUMBER = @"^(\(?(\d{3})\)?\s?-?\s?(\d{3})\s?-?\s?(\d{4}))$";
        public const string STRONGPWD = @"^(?=[\x21-\x7E]*[0-9])(?=[\x21-\x7E]*[A-Z])(?=[\x21-\x7E]*[a-z])(?=[\x21-\x7E]*[\x21-\x2F|\x3A-\x40|\x5B-\x60|\x7B-\x7E])[\x21-\x7E]{6,}$";

        public override bool Validate(string val)
        {
            return base.Validate(val) && System.Text.RegularExpressions.Regex.IsMatch(Value, Pattern);

        }
    }
}

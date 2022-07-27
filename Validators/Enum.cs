using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    public class Enum<T> : BaseValidator<T> where T : struct, IConvertible
    {

        public Enum() : this("value must be of type " + typeof(T).Name) { }
        public Enum(string errorMessage) : base(errorMessage) { }
        public bool UseValue { get; set; }

        public override bool Validate(string val)
        {
            int i = 0;
            if (UseValue && int.TryParse(val, out i))
            {
                foreach (var x in Enum.GetValues(typeof(T)))
                {
                    if ((int)x == i)
                    {
                        Assignment((T)x);
                        return true;
                    }
                }
            }
            else
            {
                try
                {
                    var oret = Enum.Parse(typeof(T), val);
                    Assignment((T)oret);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
    }
}

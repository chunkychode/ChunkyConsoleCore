using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    public class NumericRange<K> : Numeric<K> where K : struct, IConvertible, IComparable<K>, IComparable, IFormattable
    {
        public K Min { get; set; }
        public K Max { get; set; }
        public NumericRange(K min, K max)
        {
            Min = min;
            Max = max;
            ErrorMessage = string.Format("Value must be between [{0}] and [{1}]", Min, Max);
        }
        public override bool Validate(string val)
        {
            return base.Validate(val) && Convert.ToUInt64(Value) >= Convert.ToUInt64(Min) && Convert.ToUInt64(Value) <= Convert.ToUInt64(Max);
        }
    }

    public class IntRange : NumericRange<int> { public IntRange(int min, int max) : base(min, max) { } }
    public class DoubleRange : NumericRange<double> { public DoubleRange(double min, double max) : base(min, max) { } }
    public class LongRange : NumericRange<long> { public LongRange(long min, long max) : base(min, max) { } }
    public class DecimalRange : NumericRange<decimal> { public DecimalRange(decimal min, decimal max) : base(min, max) { } }
    public class FloatRange : NumericRange<float> { public FloatRange(float min, float max) : base(min, max) { } }
}

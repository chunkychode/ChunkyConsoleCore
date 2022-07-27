﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Prompts
{
    public class NumericRange<T> : Numeric<T> where T : struct, IConvertible, IComparable<T>, IComparable, IFormattable
    {
        public T Min { get { return (Validator as Validators.NumericRange<T>).Min; } set { (Validator as Validators.NumericRange<T>).Min = value; } }
        public T Max { get { return (Validator as Validators.NumericRange<T>).Max; } set { (Validator as Validators.NumericRange<T>).Max = value; } }
        public NumericRange(T min, T max)
        {
            Validator = new Validators.NumericRange<T>(min, max);
        }
    }

    public class IntRange : NumericRange<int> { public IntRange(int min, int max) : base(min, max) { } }
    public class DoubleRange : NumericRange<double> { public DoubleRange(double min, double max) : base(min, max) { } }
    public class LongRange : NumericRange<long> { public LongRange(long min, long max) : base(min, max) { } }
    public class DecimalRange : NumericRange<decimal> { public DecimalRange(decimal min, decimal max) : base(min, max) { } }
    public class FloatRange : NumericRange<float> { public FloatRange(float min, float max) : base(min, max) { } }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChunkyConsoleCore
{
    public class IncludeMethodAttribute : Attribute
    {
        public IncludeMethodAttribute() { }
        public IncludeMethodAttribute(bool isPassword) { this.IsPassword = isPassword; }

        public bool IsPassword { get; set; }
    }
}

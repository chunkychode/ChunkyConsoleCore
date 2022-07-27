using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Validators
{
    public class Directory : NonBlankString
    {
        public Directory() : this(false, false)
        {
            ErrorMessage = MustExist ? "Directory must exist" : "value may not be blank";
        }
        public Directory(bool autoCreate) : this(autoCreate, false) { }
        public Directory(bool autoCreate, bool mustExist) { AutoCreate = autoCreate; MustExist = mustExist; }
        public bool AutoCreate { get; set; }

        public bool MustExist { get; set; }

        public override bool Validate(string val)
        {
            return base.Validate(val) && AutoCreate ? System.IO.Directory.CreateDirectory(Value) != null : MustExist ? System.IO.Directory.Exists(Value) : true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Commands
{
    public class DynamicPrompterCommand : PrompterCommand
    {
        readonly System.Reflection.MethodInfo _mem;
        readonly object _source;

        public DynamicPrompterCommand(System.Reflection.MethodInfo mem, object source)
        {
            _mem = mem;
            _source = source;
        }
        public override void Execute()
        {
            _mem.Invoke(_source, Parameters);
        }
        public object[] Parameters
        {
            get
            {
                return (from p in Prompter
                        select p.Validator.GetType().GetProperty("Value").GetValue(p.Validator, null)).ToArray<object>();
            }
        }

    }
}

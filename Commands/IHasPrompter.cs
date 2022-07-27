using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Commands
{
    public interface IHasPrompter
    {
        Prompts.Prompter Prompter { get; }
        bool KeepLastAnswers { get; }
    }
}

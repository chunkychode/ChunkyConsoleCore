using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Commands
{
    public enum ExecuteOrder { none, BeforeMenu, AfterMenu }
    public enum MenuOrder { none, BeforeExecute, AfterExecute, BeforePrompt, AfterPrompt }

    public interface IHasMenu
    {
        UI.Menu Menu { get; }
        ExecuteOrder Order { get; }
        MenuOrder MenuOrder { get; }
    }
}

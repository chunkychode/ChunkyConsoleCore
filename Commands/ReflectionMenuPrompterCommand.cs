using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChunkyConsoleCore.Commands
{
    public class ReflectionMenuPrompterCommand : MenuPromptCommand
    {
        private bool _includeOnlyAttributedMembers;

        public ReflectionMenuPrompterCommand(bool AutoAdd)
        {
            _includeOnlyAttributedMembers = true;
            MenuOrder = MenuOrder.AfterPrompt;

            if (AutoAdd)
            {
                AddMembers(_includeOnlyAttributedMembers);
                AddProperties(_includeOnlyAttributedMembers);
            }
        }

        public ReflectionMenuPrompterCommand(MenuOrder menuOrder = MenuOrder.AfterPrompt, bool includeOnlyAttributedMembers = true, bool AutoAdd = true)
        {
            _includeOnlyAttributedMembers = includeOnlyAttributedMembers;

            MenuOrder = MenuOrder;
            if (AutoAdd)
            {
                AddMembers(includeOnlyAttributedMembers);
                AddProperties(includeOnlyAttributedMembers);
            }
        }

        protected void Populate()
        {
            AddMembers(_includeOnlyAttributedMembers);
            AddProperties(_includeOnlyAttributedMembers);
        }
        private void AddProperties(bool includeOnlyAttributedMembers = true)
        {
            Func<PropertyInfo, string> GetV = new Func<PropertyInfo, string>(pp =>
            {
                try
                {
                    return pp.GetValue(this, null).ToString();
                }
                catch { return ""; }
                ;
            });

            foreach (var pr in from m in GetType().GetProperties()
                               let atts = m.GetCustomAttributes(typeof(IncludeMethodAttribute), false)
                               where includeOnlyAttributedMembers ? atts != null && atts.Count() > 0 : true
                               let v = GetV(m)
                               select new { va = v, pi = m, pwd = includeOnlyAttributedMembers ? (atts[0] as IncludeMethodAttribute).IsPassword : false })
            {
                Add(pr.pi, this, pr.pwd, pr.va);
            }


        }

        private void AddMembers(bool includeOnlyAttributedMembers = true)
        {
            foreach (var mem in GetMethods(includeOnlyAttributedMembers))
            {
                var newcmd = new DynamicPrompterCommand(mem, this);

                AddMemberParamPrompts(mem, newcmd);

                Add(mem.Name, ConsoleKey.D0 + Menu.MenuItems.Count, newcmd);
            }
        }

        private static void AddMemberParamPrompts(MethodInfo mem, DynamicPrompterCommand newcmd)
        {
            foreach (var par in mem.GetParameters())
                newcmd.Prompter.AddLast(new Prompts.PromptItem() { Prompt = par.Name, Validator = Validators.BaseValidator<string>.InstanceByType(par.ParameterType) });
        }

        private IEnumerable<MethodInfo> GetMethods(bool includeOnlyAttributedMembers)
        {
            return from m in GetType().GetMethods(BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.DeclaredOnly)
                   where !m.Name.StartsWith("get_")
                   let atts = m.GetCustomAttributes(typeof(IncludeMethodAttribute), false)
                   where includeOnlyAttributedMembers ? atts != null && atts.Count() > 0 : true
                   select m;
        }
        public override void Execute() { }

    }
}
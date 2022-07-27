using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Utils
{
    public static class ConsoleHelper
    {
        public static string LineFromUser(string prompr, string defaultValue = "", bool isPassword = false, bool useFileAutoComplete = false)
        {
            Console.Write(string.Format("{0}:{1}", prompr, string.IsNullOrEmpty(defaultValue) ? "" : "[" + defaultValue + "]"));
            string sret = isPassword ? ReadPassword() : useFileAutoComplete ? ReadWithAutoComplete() : Console.ReadLine();
            return string.IsNullOrEmpty(sret) ? defaultValue : sret;
        }

        public static void Clear()
        {
            Console.Clear();
        }
        public static void SetColor(ConsoleColor ForeColor = ConsoleColor.White, ConsoleColor BackColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = BackColor;
            Console.ForegroundColor = ForeColor;
        }
        public static void WriteIn(string message, ConsoleColor ForeColor = ConsoleColor.White, ConsoleColor BackColor = ConsoleColor.Black)
        {
            var origFore = Console.ForegroundColor;
            var origBack = Console.BackgroundColor;
            Console.ForegroundColor = ForeColor;
            Console.BackgroundColor = BackColor;
            Console.Write(message);
            Console.BackgroundColor = origBack;
            Console.ForegroundColor = origFore;
        }
        public static string ReadPassword(char passwordChar = '*')
        {
            string sret = string.Empty;
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey(true);

                if (char.IsLetterOrDigit(k.KeyChar) || char.IsPunctuation(k.KeyChar) || char.IsSymbol(k.KeyChar) || char.IsWhiteSpace(k.KeyChar) && !(k.Key == ConsoleKey.Enter || k.Key == ConsoleKey.Escape))
                {
                    sret += k.KeyChar;
                    Console.Write(passwordChar);
                }
                else if (sret.Length > 0 && (k.Key == ConsoleKey.Backspace || k.Key == ConsoleKey.LeftArrow))
                {
                    sret = sret.Substring(0, sret.Length - 1);
                    Console.Write("\b \b");
                }
                else if (k.Key == ConsoleKey.Enter || k.Key == ConsoleKey.Escape)
                {
                    Console.Write(Environment.NewLine);
                }
                else
                    Console.Beep();
            }
            while (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.Escape);
            return sret;
        }

        public static string ReadWithAutoComplete()
        {
            string sret = string.Empty;
            int startpos = Console.CursorLeft;
            int tabcount = -1;
            Console.TreatControlCAsInput = true;
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey(true);
                if (k.Key != ConsoleKey.Tab && (char.IsLetterOrDigit(k.KeyChar) || char.IsPunctuation(k.KeyChar) || char.IsSymbol(k.KeyChar) || char.IsWhiteSpace(k.KeyChar) && !(k.Key == ConsoleKey.Enter || k.Key == ConsoleKey.Escape)))
                {
                    tabcount = -1;
                    sret += k.KeyChar;
                    Console.Write(k.KeyChar);
                }
                else if (sret.Length > 0 && (k.Key == ConsoleKey.Backspace || k.Key == ConsoleKey.LeftArrow))
                {
                    tabcount = -1;
                    sret = sret.Substring(0, sret.Length - 1);
                    Console.Write("\b \b");
                }
                else if (k.Key == ConsoleKey.Enter || k.Key == ConsoleKey.Escape)
                {
                    tabcount = -1;
                    Console.Write(Environment.NewLine);
                }
                else if (k.Key == ConsoleKey.Tab)
                {
                    if (tabcount > -1)
                    {

                    }
                    else
                    {
                        string pa = Path.GetFullPath(sret);
                    }
                }
                else
                    Console.Beep();
            } while (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.Escape);
            Console.TreatControlCAsInput = false;
            return sret;
        }
    }
}

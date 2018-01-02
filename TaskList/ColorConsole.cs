using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public static class ColorConsole
    {
        public static void WriteLine(string text, System.ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public static void Write(string text, System.ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}

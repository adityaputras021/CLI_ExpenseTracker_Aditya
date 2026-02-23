using CLI_ExpenseTask_Aditya.Service;
using CLI_ExpenseTask_Aditya.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLI_ExpenseTask_Aditya.Styling
{
    internal class style
    {
        public static void MainCommand()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter Command (/help): ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine().Trim().ToLower();
            service.menu(input);
            Console.ResetColor();
        }

        public static void InputCommand(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine().Trim().ToLower();
            Console.ResetColor();
        }

        public static void AskCommand(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(input);
            Console.ResetColor();
        }

        public static void InfoCommand(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        public static void ErrorCommand(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input);
            Console.ResetColor();
        }

    }
}

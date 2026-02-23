using CLI_ExpenseTask_Aditya.Data;
using CLI_ExpenseTask_Aditya.Styling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CLI_ExpenseTask_Aditya.Service
{
    internal class service
    {
        

        public static void menu(string input)
        {
            switch(input)
            {
                case "/help" or "help":
                    style.InfoCommand("=================================");
                    style.InfoCommand("         EXPENSE TRACKER         ");
                    style.InfoCommand("=================================");
                    style.InfoCommand("Available Commands:");
                    style.InfoCommand("  1. add            - Add new expense");
                    style.InfoCommand("  2. view           - View all expenses");
                    style.InfoCommand("  3. update         - Update an expense");
                    style.InfoCommand("  4. delete         - Delete an expense");
                    style.InfoCommand("  5. summary        - Show total expenses");
                    style.InfoCommand("  6. summary-month  - Show monthly total");
                    style.InfoCommand("  7. exit           - Exit application");
                    style.MainCommand();
                    break;
                case "add":
                    addInput();
                    break;
                case "view":
                    FileService.ViewData();
                    break;
                case "update":
                    updateInput();
                    break;
                case "delete":
                    deleteInput();
                    break;
                case "summary":
                    FileService.TotalSummary();
                    break;
                case "summary-month":
                    sumInput();
                    break;
                case "exit":
                    return;
                    break;
            }
        }

        public static void addInput()
        {
            style.AskCommand("name: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string name = Console.ReadLine().Trim().ToLower();
            style.AskCommand("description: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string desk = Console.ReadLine().Trim().ToLower();
            style.AskCommand("mount: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string mount = Console.ReadLine().Trim().ToLower();

            data tambah = new data
            {
                Name = name,
                Description = desk,
                Amount = int.Parse(mount),
                Date = DateTime.Now
            };
            FileService.AddData(tambah);
        }

        public static void updateInput()
        {
            style.AskCommand("id: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            int id = Convert.ToInt32(Console.ReadLine().Trim().ToLower());
            style.AskCommand("name: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string name = Console.ReadLine().Trim().ToLower();
            style.AskCommand("description: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string desk = Console.ReadLine().Trim().ToLower();
            style.AskCommand("mount: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string mount = Console.ReadLine().Trim().ToLower();

            data edit = new data
            {
                Name = name,
                Description = desk,
                Amount = int.Parse(mount),
            };
            FileService.UpdateData(id, edit);
        }

        public static void deleteInput()
        {
            style.AskCommand("id: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            int id = Convert.ToInt32(Console.ReadLine().Trim().ToLower());
            FileService.DeleteData(id);
        }

        public static void sumInput()
        {
            style.AskCommand("month: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            int bulan = Convert.ToInt32(Console.ReadLine().Trim().ToLower());
            FileService.TotalMonth(bulan);
        }
    }
}

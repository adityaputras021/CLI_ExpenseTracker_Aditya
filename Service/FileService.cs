using CLI_ExpenseTask_Aditya.Data;
using CLI_ExpenseTask_Aditya.Styling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CLI_ExpenseTask_Aditya.Service
{
    internal class FileService
    {
        private static string FilePath = "Data.json";
        public static int GetID()
        {
            List<data> listdata = GetData();
            if (listdata.Count == 0 || listdata == null)

                return 1;

            return (int)listdata.Max(d => d.ID) + 1;

        }


        public static List<data> GetData()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);

                    if (string.IsNullOrEmpty(json))
                    {
                        return new List<data>();
                    }

                    return JsonSerializer.Deserialize<List<data>>(json);
                }
                return new List<data>();
            }
            catch
            {
                File.WriteAllText(FilePath, "[]");
                return new List<data>();
            }
        }

        public static bool AddData(data tambah)
        {
            try
            {
                List<data> listdata = GetData();
                tambah.ID = GetID();

                listdata.Add(tambah);

                string jsonstring = JsonSerializer.Serialize(listdata, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, jsonstring);
                style.InfoCommand("Data added successfully!");
                style.MainCommand();

                return true;
            }
            catch (Exception ex)
            {
                style.ErrorCommand("Data added failed! Error: " + ex.Message);
                style.MainCommand();

                return false;
            }
        }

        public static bool DeleteData(int id)
        {
            try
            {
                List<data> listdata = GetData();
                data? dataToDelete = listdata.FirstOrDefault(d => d.ID == id);

                if (dataToDelete == null)
                {
                    style.ErrorCommand("Data with that ID was not found!");
                    style.MainCommand();
                }

                listdata.Remove(dataToDelete);

                string jsonstring = JsonSerializer.Serialize(listdata, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, jsonstring);
                style.InfoCommand("Data deleted successfully!");
                style.MainCommand();

                return true;
            }
            catch (Exception ex)
            {
                style.ErrorCommand("Data deleted failed! Error: " + ex.Message);
                style.MainCommand();

                return false;
            }
        }

        public static void ViewData()
        {
            List<data> listdata = GetData();
            if (listdata.Count == 0)
            {
                style.InfoCommand("No data available.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("              EXPENSE LIST              ");
            Console.WriteLine("========================================");
            Console.ResetColor(); foreach (var item in listdata)
            {
                Console.WriteLine($"{"ID".PadRight(12)} : {item.ID}");
                Console.WriteLine($"{"Name".PadRight(12)} : {item.Name}");
                Console.WriteLine($"{"Description".PadRight(12)} : {item.Description}");
                Console.WriteLine($"{"Amount".PadRight(12)} : {item.Amount:C}");
                Console.WriteLine($"{"Date".PadRight(12)} : {item.Date:dd MMM yyyy}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }
            style.MainCommand();
        }

        public static bool UpdateData(int id, data edit)
        {
            try
            {
                List<data> listdata = GetData();

                data? exitingData = listdata.FirstOrDefault(i => i.ID == id);

                if (exitingData == null)
                {
                    style.ErrorCommand("Data with that ID was not found!");
                    style.MainCommand();
                }

                exitingData.Name = edit.Name;
                exitingData.Description = edit.Description;
                exitingData.Amount = edit.Amount;

                string jsonstring = JsonSerializer.Serialize(listdata, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, jsonstring);
                style.InfoCommand("Data updated successfully!");
                style.MainCommand();
                return true;
            }
            catch (Exception ex)
            {
                style.ErrorCommand("Data failed to update! Error: " + ex.Message);
                style.MainCommand();
                return false;
            }
        }

        public static void TotalSummary()
        {
            List<data> listdata = GetData();
            
            int total = listdata.Sum(d => d.Amount);

            style.InfoCommand($"\nTotal Expenditure: {total}");
            style.MainCommand();
        }

        public static void TotalMonth(int month)
        {
            List<data> listdata = GetData();

            int totalpermonth = listdata.Where(d => d.Date.Month == month).Sum(d => d.Amount);

            style.InfoCommand($"\nTotal Expenditure in the month {month}: {totalpermonth}");
            style.MainCommand();
        }
    }
}

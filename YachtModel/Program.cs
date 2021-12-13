using ConsoleApp8;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace YachtModel
{


    internal class Program
    {
        internal static List<Yacht> Yachts { get; set; }
        private static string Country { get; set; }
        private static string Title { get; set; }
        private static int Key { get; set; }
        private static int Action { get; set; }

        static void Main()
        {
            Action = int.Parse(Console.ReadLine());

            Yachts = new List<Yacht>();
            // Список команд
            static void ListCommand()
            {
                Console.WriteLine("\n1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View");
                Console.WriteLine("5. Serch");
                Console.WriteLine("6. Exit program");

            }
            // Регистрация
            while (Key != 2)
            {
                Console.WriteLine("Registration (1) | Cancel (2)");
                Message("Enter the command: ", ConsoleColor.Yellow);
                Key = int.Parse(Console.ReadLine());
                if (Key == 1)
                {
                    Console.WriteLine("Registration");
                    Message("Title: ", ConsoleColor.Blue);
                    Title = Console.ReadLine();
                    Message("Country: ", ConsoleColor.Blue);
                    Country = Console.ReadLine();

                    var yachtRegistration = Yachts.FirstOrDefault(item => item.Title == Title && item.Country == Country);
                    if (yachtRegistration != null)
                    {
                        Message("Registration completed!\n", ConsoleColor.Green);
                        while (Action != 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            ListCommand();
                            Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                Message("Enter the command: ", ConsoleColor.DarkRed);

                                Action = int.Parse(Console.ReadLine());
                                switch (Action)
                                {
                                    // Добавление
                                    case 1:
                                        Yachts.Add(ActionYacht(new Yacht()));
                                        break;
                                    // Редактирование
                                    case 2:

                                        Console.Write("Enter ID: ");
                                        int idEdit = int.Parse(Console.ReadLine());
                                        var editYacht = Yachts.FirstOrDefault(item => item.ID == idEdit);
                                        if (editYacht != null)
                                        {
                                            ActionYacht(editYacht);
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;
                                    // Удаление
                                    case 3:

                                        Console.Write("Enter ID: ");
                                        int idRemove = int.Parse(Console.ReadLine());
                                        var removeYacht = Yachts.FirstOrDefault(item => item.ID == idRemove);
                                        if (removeYacht != null)
                                        {
                                            Yachts.Remove(removeYacht);

                                            Message("Success!", ConsoleColor.Green);
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;

                                    // Просмотр
                                    case 4:

                                        if (Yachts.Any())
                                        {
                                            foreach (var yacht in Yachts)
                                            {
                                                Console.WriteLine(yacht.GetInfo());
                                            }
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;
                                    case 5:
                                        // Поиск
                                        Console.Write("Enter data: ");
                                        string search = Console.ReadLine();
                                        var searchYacht = Yachts.Where(item => item.ID.ToString().Contains(search) || item.View.Contains(search) ||
                                        item.Country.Contains(search) || item.Title.Contains(search)).ToList();
                                        if (searchYacht.Any())
                                        {
                                            foreach (var item in searchYacht)
                                            {
                                                Console.WriteLine(item.GetInfo());
                                            }
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Message("Error! Not found...\n", ConsoleColor.Red);
                    }
                }

            }
        }
        // Сообщение
        internal static void Message(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Ввод команд
        internal static Yacht ActionYacht(Yacht yacht)
        {
            try
            {
                if (yacht.ID == 0)
                {
                    yacht = new Yacht();
                    Console.Write("Введите ваше ID: ");
                    yacht.ID = int.Parse(Console.ReadLine());
                }
                Console.Write("Enter title hotel: ");
                yacht.Title = Console.ReadLine();
                Message("Success!\n", ConsoleColor.Green);
                Console.Write("Enter country:");
                yacht.Country = Console.ReadLine();
                Console.Write("Enter Country:");
                yacht.View = Console.ReadLine();
                return yacht;

            }
            catch (Exception ex)
            {
                Message($"{ex.Message}\n", ConsoleColor.Red);
                return null;
            }
        }
    }
}
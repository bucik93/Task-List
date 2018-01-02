using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaskList
{
    public class Options
    {
        public static void ExitProgram()
        {
            Environment.Exit(0);
        }

        public static void Footer()
        {
            ColorConsole.WriteLine("Witamy w Menadżer zadań. Aby rozpocząć wciśnij dowolny klawisz :)", ConsoleColor.Blue);
        }

        public static void PrintOptions()
        {
            ColorConsole.WriteLine("Wybierz jedną z opcji i wprowadź odpowiednią komendę", ConsoleColor.Blue);
            ColorConsole.WriteLine("'a' - Dodanie nowego zadania", ConsoleColor.Blue);
            ColorConsole.WriteLine("'d' - Pokaż zadania", ConsoleColor.Blue);
            ColorConsole.WriteLine("'r' - Zaznacz, które zadanie chcesz usunąć", ConsoleColor.Blue);
            ColorConsole.WriteLine("'s' - Zapisz zadanie w pliku", ConsoleColor.Blue);
            ColorConsole.WriteLine("'l' - Odczytaj dane z pliku", ConsoleColor.Blue);
            ColorConsole.WriteLine("'e' - Wyjście z programu", ConsoleColor.Blue);
        }


        public static void ShowTask()
        {
            ConsoleColor color = ConsoleColor.Cyan;
            ColorConsole.WriteLine("Istniejące zadania:", color);
            string text = File.ReadAllText(@"file\Task" + ".txt");
            Console.WriteLine(text);

            //string command = "";
            //if (string.IsNullOrEmpty(command))
            //{
            //    Console.WriteLine("Wyświetl Wszystkie zadania");
            //    ConsoleKeyInfo c = Console.ReadKey();
            //    Console.WriteLine();
            //    char key = c.KeyChar;
            //    if (key == 'Q')
            //    {
            //        Options.ShowTask();
            //    }
            //}
        }

        public static void Display()
        {
            ConsoleColor color = ConsoleColor.Cyan;
            ColorConsole.WriteLine("Wpisz nazwę pliku w którym powinny znajdować się twoje zadania.", color);
            string fileName = Console.ReadLine();

            bool exist = File.Exists(@"file\" + fileName + ".txt");


            if (exist == true)
            {
                ColorConsole.WriteLine("Istniejące zadania:", color);
                string text = File.ReadAllText(@"file\" + fileName + ".txt");
                Console.WriteLine(text);

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    ColorConsole.WriteLine("Zadania zostały wyświetlone", color);
                }
            }
            else
            {
                ColorConsole.WriteLine("Nieodnaleziono pliku.", color);
            }
        }

        public static List<Task> AddTask(List<Task> taskList, Task task)
        {
            List<Task> list = new List<Task>();

            if (taskList.Count == 0)
            {
                list.Add(task);
                return list;
            }
            bool flag = true;
            for (int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].startDate < task.startDate)
                {
                    list.Add(taskList[i]);
                    if (i == taskList.Count - 1)
                    {
                        list.Add(task);
                    }
                }
                else
                {
                    if (flag)
                    {
                        list.Add(task);
                        flag = false;
                    }
                    list.Add(taskList[i]);
                }
            }
            return list;
        }

        public static void WrongCommand()
        {
            ConsoleColor color = ConsoleColor.Red;
            ColorConsole.WriteLine("Wpisałeś złą komendę!!! Wybierz jedną z komend przedstawionych poniżej :) ", color);

        }

        public static void Save(string[] text)
        {
            if (!File.Exists(@"file\Task.txt"))
            {
                File.Create((@"file\Task.txt"));
            }
            File.WriteAllLines(@"file\Task.txt", text);
        }

        public static void Save(List<Task> listTask)
        {
            string[] addData = new string[listTask.Count];
            ConsoleColor color = ConsoleColor.Green;
            int i = 0;
            foreach (var item in listTask)
            {
                Task task = item;
                string data = task.Export();
                addData[i++] = data;
            }

            Options.Save(addData);
            ColorConsole.WriteLine("Zadanie zostało zapisane do listy zadań:", color);
        }


    }
}


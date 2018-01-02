using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup.Configure();

            List<Task> list = new List<Task>();
            Options.Footer();
            Console.ReadKey();
            string command = "";
            Options.ShowTask();

            while (true)
            {
                Options.PrintOptions();
                command = Console.ReadLine();
                command = command.ToLower();
                //wyjście z programu
                if (command == "e")
                {
                    Options.ExitProgram();
                }
                //dodanie nowego zadania
                else if (command == "a")
                {
                    Task task = new Task();
                    task.AddTask();
                    list = Options.AddTask(list, task);
                }
                //wyświetla zadania z pliku
                else if (command == "d")
                {
                    Options.Display();
                }
                //zapis do pliku
                else if (command == "s")
                {
                    Options.Save(list);
                }
                else if (command == "r")
                {
                    

                }
                else
                {
                    Options.WrongCommand();
                }

            }
        }
    }
}

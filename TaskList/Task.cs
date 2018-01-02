using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TaskList
{
    public class Task
    {
        public string description;
        public DateTime startDate;
        public DateTime? endDate;
        public bool allDay;
        public bool Important;

        public void AddTask()
        {
            System.ConsoleColor color = System.ConsoleColor.Yellow;
            ColorConsole.WriteLine("Dodawanie nowego zadania. Dołacz opis do nowego zadania:", color);
            description = Console.ReadLine();

            ColorConsole.WriteLine("Wpisz datę rozpoczęcia zadania według formatu:{yyyy-MM-dd}", color);
            var loadDate = Console.ReadLine();
            startDate = Convert.ToDateTime(loadDate);

            ColorConsole.WriteLine("Potwierdź czy zadanie ma być całodniowe? {t/n}", color);
            var allday = Console.ReadLine();

            if (allday == "n")
            {
                allDay = false;
                ColorConsole.WriteLine("Wpisz godzinę, rozpoczęcia zadania według formatu {hh:mm:ss}", color);
                loadDate = Console.ReadLine();
                TimeSpan time = new TimeSpan(Convert.ToDateTime(loadDate).Hour, Convert.ToDateTime(loadDate).Minute, Convert.ToDateTime(loadDate).Second);
                startDate += time;

                ColorConsole.WriteLine("Wybierz jedną z opcji", color);
                ColorConsole.WriteLine("Wpisz pełną datę zakończenia zadania używając komendy 'AddDate'", color);
                ColorConsole.WriteLine("Wpisz jak długo będzie trwało dane zadanie według określonego formatu {hh:mm:ss}.", color);
                loadDate = Console.ReadLine();

                if (loadDate != "AddDate")
                {
                    time = new TimeSpan(Convert.ToDateTime(loadDate).Hour, Convert.ToDateTime(loadDate).Minute, Convert.ToDateTime(loadDate).Second);
                    startDate += time;
                }
                else
                {
                    ColorConsole.WriteLine("Wpisz datę ukończenia zadania według formatu {yyyy-MM-dd hh:mm:ss", color);
                    loadDate = Console.ReadLine();
                    endDate = Convert.ToDateTime(loadDate);
                }
            }
            else if (allday == "t")
            {
                allDay = true;
            }
            ColorConsole.WriteLine("Określ czy zadanie powinno być ważne? {t/n}", color);
            string important = Console.ReadLine();

            if (important == "t")
            {
                Important = true;
            }
            else if (important == "n")
            {
                Important = false;
            }
            else
            {
                ColorConsole.WriteLine("Wpisałeś nieodpowiednie komendy!!! Wpisz znak 'T' albo znak 'N'", System.ConsoleColor.Red);
            }
        }

        public string Export()
        {
            string allday;
            string important;

            if (allDay)
            {
                allday = "t";
            }
            else
            {
                allday = "n";
            }

            if (Important)
            {
                important = "t";
            }
            else
            {
                important = "n";
            }

            string data = $"{description};{startDate};{endDate};{allday};{important}";
            return data;
        }

      

       

       

    }
}

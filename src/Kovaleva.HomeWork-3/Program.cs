using System;
using System.Collections.Generic;

namespace Kovaleva.HomeWork_3
{
    class Program
    {
        static void Main(string[] args)


        {
            DateTime start;
            DateTime end;
            while (true)
            {
               
                start = DateTime.Parse(Console.ReadLine());
                end = DateTime.Parse(Console.ReadLine());

                if (end < start)
                {
                    Console.WriteLine("Ошибка! Попробуйте снова!");
                }
                else
                 break;                

            }
            var dayOfWeek = Console.ReadLine();
            //var dayOfWeek = Console.ReadLine();
            //DateTime[] Array = { };

            //var listOfDays = new List<DateTime>();
            //var FilterDays = new List<DateTime>();

            //while (end >= start)
            //{ 
            //    if (start.DayOfWeek.ToString() == dayOfWeek)
            //        FilterDays.Add(start);
            //    start.AddDays(1);
            // }

            ////do
            ////{ }
            ////while ();

            ////for (int i = 0;; i++)
            ////{
            ////    if (end == start)
            ////    { start.AddDays(1); }
            ////}
            ///
           var list =  GetDaysOfUserInput(start, end, dayOfWeek);
            Console.ReadLine();
        }

        static List<DateTime> GetDaysOfUserInput(DateTime start, DateTime end, string dayOfWeek)
        {
            
            DateTime[] Array = { };

            
            var FilterDays = new List<DateTime>();

            while (end >= start)
            {
                if (start.DayOfWeek.ToString() == dayOfWeek)
                    FilterDays.Add(start);
                start.AddDays(1);
            }

            foreach (var day in FilterDays)
            {

            }

            return FilterDays;
           
        }
    }
}

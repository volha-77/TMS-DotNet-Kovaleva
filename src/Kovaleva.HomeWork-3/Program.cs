using System;
using System.Collections.Generic;

namespace Kovaleva.HomeWork_3
{
    class Program

    {
        private enum MyDaysOfWeek
        {
            monday = 1,
            tuesday,
            wednesday,
            thursday,
            friday,
            saturday,
            sunday,
        }
        static void Main(string[] args)


        {
            DateTime start;
            DateTime end;




            while (!InputDatePeriod(out start, out end)) ;


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
            var list = GetDaysOfUserInput(start, end, dayOfWeek);
            Console.ReadLine();
        }

        private static bool InputDate(out DateTime date, string NameOfDate)
        {
            Console.WriteLine($"Please input {NameOfDate} date");
            bool result = DateTime.TryParse(Console.ReadLine(), out date);
            if (result != true) Console.WriteLine("Date is incorrect! Try again!");
            return result;

        }

        private static bool InputDatePeriod(out DateTime start, out DateTime end)
        {
            while (InputDate(out start, nameof(start)) != true) ;
            while (InputDate(out end, nameof(end)) != true) ;

            bool result = (start > end) ? true : false;
            if (!result) Console.WriteLine("Error! Start date is greater than end date. Try again!");
            return result;

        }

        private static (bool result, string day) InputDayOfWeek()
        {
            (bool, string) tupleResult;
            Console.WriteLine("Please input day of week:");
            string day = Console.ReadLine().ToUpper().Trim();
            var result = false;
            for (int i = 1; i <= 7; i++)
            {
                var myDay = (MyDaysOfWeek)i;
                if (myDay.ToString().ToUpper() == day)
                {
                    result = true;
                    break;
                }
            }
            if (!result) Console.WriteLine("You input incorrect day of week! Try again!");
            tupleResult = (result, day);
            return tupleResult;
        }

        private static string GetDay()
        {
            var inputResult = (result: false, day: "");
            while (true)
            {
                inputResult = InputDayOfWeek();
                if (inputResult.result) break;
            }

            return inputResult.day;

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

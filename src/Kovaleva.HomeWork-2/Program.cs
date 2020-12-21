using System;

namespace Kovaleva.HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String dateStr;

            Console.WriteLine("Введите дату:");
            DateTime date1;
            var result = false;
            do
            {
                dateStr = Console.ReadLine();
                result = DateTime.TryParse(dateStr, out date1);
                if (!result) Console.WriteLine("Вы ввели неверный формат даты, повторите ввод даты");
                           }
            while (!result);

            Console.WriteLine($"день недели {dateStr} это - {date1.DayOfWeek}");
        }
    }
}

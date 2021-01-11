using System;
using System.Collections.Generic;

namespace Kovaleva.HomeWork_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card1 = new Card(long.Parse("1234 4567 3456 3212".Replace(" ", "")), 2311);
            Card card2 = new Card(long.Parse("3323 5647 8900 6765".Replace(" ", "")), 1315, "", 1500);

            ATM atm = new ATM(new List<Card>() { card1, card2 });

            atm.Notify += card1.PrintBalance;
           
            atm.CurrentCard = card1;
            Console.WriteLine($"Введите pin карты {card1.PrintCardNumber()}") ;
            int pin1 = int.Parse(Console.ReadLine());
            if (atm.CheckPin(pin1))
            {
                Console.WriteLine("Какую сумму добавить?");
                decimal sum = decimal.Parse(Console.ReadLine());
                atm.operation = atm.AddSum;
                atm.operation(sum);
                //atm.PrintBalance();
            }
            atm.Notify -= card1.PrintBalance;
            atm.Notify += card2.PrintBalance;
            atm.CurrentCard = card2;
            Console.WriteLine($"Введите pin карты {card2.PrintCardNumber()}");
            int pin2 = int.Parse(Console.ReadLine());
            if (atm.CheckPin(pin2))
            {
                Console.WriteLine("Какую сумму снять?");
                decimal sum = decimal.Parse(Console.ReadLine());
                atm.operation = atm.WithdrawSum;
                atm.operation(sum);
                //atm.PrintBalance();
            }


        }
    }
}

using System;
using System.Collections.Generic;

namespace Kovaleva.HomeWork_6
{
    class Program
    {
       // public delegate bool DelOp(decimal sum);
        
        //public Predicate<decimal> DelOp;
        static void Main(string[] args)
        {
            Card card1 = new Card(long.Parse("1234 4567 3456 3212".Replace(" ", "")), 2311, "Иванов");
            Card card2 = new Card(long.Parse("3323 5647 8900 6765".Replace(" ", "")), 1315, "Петров", 1500);

            ATM atm = new ATM(new List<Card>() { card1, card2 });

            atm.CurrentCard = card1;
            ChooseAndDoOperation(atm);

            atm.CurrentCard = card2;
            ChooseAndDoOperation(atm);

        }

        static void DoOperation(ATM atm, Predicate<decimal> operation)
        {
            Card card = atm.CurrentCard;
            if (operation == null) return;

            atm.Notify += card.PrintBalance;
           
            Console.WriteLine($"Введите pin карты {card.PrintCardNumber()}");
            int pin = int.Parse(Console.ReadLine());
            if (atm.CheckPin(pin))
            {
                if (operation == atm.WithdrawSum)
                    Console.WriteLine("Какую сумму снять?");
                else if (operation == atm.AddSum)
                    Console.WriteLine("Какую сумму добавить?");
                else
                    return;

                decimal sum = decimal.Parse(Console.ReadLine());
                operation(sum);
                atm.Notify -= card.PrintBalance;
            }
        }

        static void ChooseAndDoOperation(ATM atm)
        {
            Console.WriteLine($"Уважаемый {atm.CurrentCard.OwnerName}, выберите операцию для {atm.CurrentCard.PrintCardNumber()}. Для добавления суммы нажмите \"+\". Для снятия суммы нажмите \"-\"");

            char choice = Console.ReadKey().KeyChar;

            Console.WriteLine();

            switch (choice)

            {
                case '+':
                    { DoOperation(atm, atm.AddSum); break; }

                case '-':
                    { DoOperation(atm, atm.WithdrawSum); break; }
                default:
                    break;
            }
        }
    }
}

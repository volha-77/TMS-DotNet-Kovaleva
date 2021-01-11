using System;
using System.Collections.Generic;
using System.Text;

namespace Kovaleva.HomeWork_6
{
    public class Card
    {
        public long CardNumber { get; set; }
        public int Pin { get; set; }
        public decimal Balance { get; set; }
        public string OwnerName { get; set; }

        public Card(long cardNumber, int pin, string ownerName, decimal balance = 0)
        {
            CardNumber = cardNumber;
            Pin = pin;
            OwnerName = ownerName;
            Balance = balance;
        }

        public Card(long cardNumber, int pin)
        {
            CardNumber = cardNumber;
            Pin = pin;
        }

        public void PrintBalance()
        { Console.WriteLine($"Текущий баланс: {Balance}"); }

        public string PrintCardNumber()
        { char[] array = CardNumber.ToString().ToCharArray();
            List<char> list = new List<char>();
            for (int i = 0; i < array.Length; i++)
            {
                list.Add(array[i]);
                if (((i+1)%4 == 0)&&(i!= (array.Length - 1)))
                { list.Add(' '); }

            }
            
            char[] arrayCopy = list.ToArray();
            return new string(arrayCopy);

        }

    }
}

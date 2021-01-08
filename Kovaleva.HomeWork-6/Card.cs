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


    }
}

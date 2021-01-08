using System;
using System.Collections.Generic;
using System.Text;

namespace Kovaleva.HomeWork_6
{
    internal class Card
    {
        public int CardNumber { get; set; }
        public int Pin { get; set; }
        public decimal Balance { get; set; }
        public string OwnerName { get; set; }

        public Card(int cardNumber, int pin, string ownerName, decimal balance = 0)
        {
            CardNumber = cardNumber;
            Pin = pin;
            OwnerName = ownerName;
            Balance = balance;
        }

        public Card(int cardNumber, int pin)
        {
            CardNumber = cardNumber;
            Pin = pin;
        }


    }
}

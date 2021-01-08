using System;
using System.Collections.Generic;
using System.Text;

namespace Kovaleva.HomeWork_6
{
    public class ATM
    {private readonly List<Card> CardsList;

        public Card CurrentCard { get; set; }
        public bool CheckPin(int pin)
        {
            return false;
        }

        public bool AddSum(decimal sum)
        {
            CurrentCard.Balance += sum;
            return true;
        }
    }
}

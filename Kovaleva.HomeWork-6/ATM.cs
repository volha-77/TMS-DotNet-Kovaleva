using System;
using System.Collections.Generic;


namespace Kovaleva.HomeWork_6
{
    public class ATM
    {
        private readonly List<Card> CardsList = new List<Card>();
        public delegate void AccountHandler();
        public event AccountHandler Notify;

        public Card CurrentCard { get; set; }
        public bool CheckPin(int pin)
        {
            Card cardCopy = null;
            foreach (var card in CardsList)
            {
                if (card.CardNumber == CurrentCard.CardNumber) cardCopy = card;
            }

            if (cardCopy != null)
            { if (cardCopy.Pin == pin) return true; }

            return false;
        }

        public ATM(List<Card> cardsList)
        {

            foreach (var card in cardsList)
            {
                Card cardCopy = new Card(card.CardNumber, card.Pin);
                CardsList.Add(cardCopy);
            }
        }

        public bool AddSum(decimal sum)
        {
            CurrentCard.Balance += sum;
            Notify?.Invoke();
            return true;
        }

        public bool WithdrawSum(decimal sum)
        {
            if (CurrentCard.Balance >= sum)
            {
                CurrentCard.Balance -= sum;
                Notify?.Invoke();
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно средств!");
                Notify?.Invoke();
                return false;
            }

        }

        //public void PrintBalance()
        //{ Console.WriteLine($"Текущий баланс: {CurrentCard.Balance}"); }

        public Predicate<decimal> operation;
    }
}

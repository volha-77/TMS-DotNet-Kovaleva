using System;

namespace Kovaleva.HomeWork_5.Models
{
    public class Cage<AnimalBase>
    {
        private int _volume { get; set; }
        private int _number;
        public AnimalBase Animal { get; set; }

        public Cage(int number, AnimalBase animal)
        {
            _number = number;
            Animal = animal;
        }

        public Cage(int number)
        { _number = number; }

        public Cage()
        { }

        public void PrintCageInfo()
        { Console.WriteLine($"#{_number}:{Animal}"); }
    }
}

using System;

namespace Kovaleva.HomeWork_5.Models
{
    public class Cage<AnimalBase>
    {
        private int _volume { get; set; }
        private int _number;
        public AnimalBase Animal { get; set; }
        public int Volume
        {
            get{ return _volume; }

            set { _volume = value; }
        }

        public int Number
        {
            get { return _number; }

            set { _number = value; }
        }
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

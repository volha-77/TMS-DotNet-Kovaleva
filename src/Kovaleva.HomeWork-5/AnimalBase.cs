using System;

namespace Kovaleva.HomeWork_5
{
    abstract class AnimalBase
    {
        public string name { get; set; }
        public double weight { get; set; }
        public double age { get; set; }

        public int pawsNumber { get; set; }

        public void Speak()
        {
            Console.WriteLine($"I am {name}");
        }

        public void Eat(object meal)
        {
            Console.WriteLine($"I eat {meal}");
        }

        public void Sleap(int duration)
        {
            Console.WriteLine("I'm sleaping");
        }
    }
}

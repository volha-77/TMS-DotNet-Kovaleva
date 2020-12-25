using System;

namespace Kovaleva.HomeWork_5
{
    public abstract class AnimalBase
    {
        public string name;

        public double Name { get; set; }
        public double Weight { get; set; }
        public double Age { get; set; }

        public int PawsNumber { get; set; }

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

using System;

namespace Kovaleva.HomeWork_5
{
    public class Cat : AnimalBase
    {
        /// <summary>
        /// кличка кота
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// статический конструктор
        /// </summary>
        //static Cat()
        //{ Name = "Cat"; }
        public Cat()
        { Name = "Cat"; }

        public override void Eat(object meal)
        {
           Console.WriteLine($"I am  Cat {Nickname}, i'm eating {meal}");
        }

    }
}

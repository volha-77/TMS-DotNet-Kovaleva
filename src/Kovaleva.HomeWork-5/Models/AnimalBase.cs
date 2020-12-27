using System;

namespace Kovaleva.HomeWork_5
{
    public abstract class AnimalBase
    {
        /// <summary>
        /// название животного
        /// </summary>
        public static string Name;
        /// <summary>
        /// вес
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// возраст
        /// </summary>
        public double Age { get; set; }
        /// <summary>
        /// количество лап
        /// </summary>
        public int PawsNumber { get; set; }
        /// <summary>
        /// метод Говорить
        /// </summary>
        public void Speak()
        {
            Console.WriteLine($"I am {Name}");
        }
        /// <summary>
        /// Метод Есть с параметром Еда
        /// </summary>
        /// <param name="meal"></param>
        public void Eat(object meal)
        {
            Console.WriteLine($"I eat {meal}");
        }
        /// <summary>
        ///  Метод Спать с параметром Продолжительность сна в часах
        /// </summary>
        /// <param name="duration"></param>
        public void Sleap(int duration)
        {
            for (int i = 0; i < duration - 1; i++)
            {
                Console.WriteLine($"I've been sleaping for {i} our(s)");
            }
           
        }
    }
}

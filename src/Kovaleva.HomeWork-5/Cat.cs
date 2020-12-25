namespace Kovaleva.HomeWork_5
{
    public class Cat : AnimalBase
    {
        /// <summary>
        /// кличка кота
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// статический конструктор
        /// </summary>
        static Cat()
        { name = "Cat"; }
    }
}

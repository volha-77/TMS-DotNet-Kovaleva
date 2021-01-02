using Kovaleva.HomeWork_5.Managers;
using System;

namespace Kovaleva.HomeWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat { Nickname = "Murzik", Age = 4 };

           var zooManager = new ZooManager();
            zooManager.PutInCage(cat, 2);
            zooManager.FeedAnimal(zooManager.Cages.Count);
            zooManager.PrintInfo();

        }
    }
}

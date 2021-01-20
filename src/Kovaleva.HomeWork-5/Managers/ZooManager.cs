using Kovaleva.HomeWork_5.Interfaces;
using Kovaleva.HomeWork_5.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kovaleva.HomeWork_5.Managers
{
    class ZooManager : IZooKeeper, ICages
    {
        //public List<Cage<AnimalBase>> Cages { get; set; } = new List<Cage<AnimalBase>>();
        public List<Cage> Cages { get; set; } = new List<Cage>();

        public void PrintInfo()
        {
            foreach (var cage in Cages)
            {
                cage.PrintCageInfo();

            }
        }

        public void PutInCage(AnimalBase animal, int volume)
        {
            int number = Cages.Count + 1;
            //?<AnimalBase>
            //var cage = new Cage<AnimalBase>(number, animal);
            var cage = new Cage(number, animal);
            cage.Volume = volume;
            Cages.Add(cage);
            Console.WriteLine($"{animal.AnimalName()} is put in cage #{cage.Number}");
        }

        public void FeedAnimal(int number)
        {
            if (number <= 0) { Console.WriteLine("Wrong cage number!"); return; }
            if (Cages.Count == 0) { Console.WriteLine("Еhere are no cages yet!"); return; }
            var cage = Cages[number - 1];
            AnimalBase animal = cage.Animal;
            Console.WriteLine($"Now we will feed the {animal.AnimalName()}");
            switch (animal.AnimalName())
            {
                case "Cat":
                    animal.Eat("meat");
                    break;
                default:
                    animal.Eat("meal");
                    break;
            }
        }

    }
}

using Kovaleva.HomeWork_5.Interfaces;
using Kovaleva.HomeWork_5.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kovaleva.HomeWork_5.Managers
{
    class ZooManager : IZooKeeper, ICages
    {
        public List<Cage<AnimalBase>> Cages { get; set; } = new List<Cage<AnimalBase>>();

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
            var cage = new Cage<AnimalBase>(number, animal);
            cage.Volume = volume;
            Cages.Add(cage);
            Console.WriteLine($"{animal.Name} is put in cage #{cage.Number}");
        }

        public void FeedAnimal(int number)
        {
            var cage = Cages[number - 1];
            AnimalBase animal = cage.Animal;
            Console.WriteLine($"Now we will feed the {animal.Name}");
            switch (animal.Name)
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

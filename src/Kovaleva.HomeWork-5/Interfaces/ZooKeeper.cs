using System;
//почему здесь не требует подключения пространства имен Models, а в Cages требует?
//using Kovaleva.HomeWork_5.Models;
using System.Collections.Generic;
using System.Text;

namespace Kovaleva.HomeWork_5.Interfaces
{
    interface IZooKeeper
    {public void PutInCage(AnimalBase animal)
        {}
        /// <summary>
        ///Покормить кого-то
        /// </summary>
        /// <param name="animal"></param>
        public void FeedAnimal(AnimalBase animal)
        { }

        /// <summary>
        ///Покормить с параметром Номер клетки
        /// </summary>
        /// <param name="number"></param>
        public void FeedAnimal(int number)
        { }
    }
}

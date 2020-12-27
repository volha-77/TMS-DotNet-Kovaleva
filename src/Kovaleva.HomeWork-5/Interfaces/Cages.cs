using Kovaleva.HomeWork_5.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kovaleva.HomeWork_5.Interfaces
{
    public interface ICages
    { List <Cage<AnimalBase>> Cages { get; set; }
      public void PrintInfo()
        { }
    }
}

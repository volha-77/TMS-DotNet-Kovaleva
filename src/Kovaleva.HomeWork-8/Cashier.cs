using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.ShopSimulator
{
    internal class Cashier
    {
        public int TimeToProcess { get;  }

        public string Name { get; }
        private static Random rnd = new Random();

        public Cashier()
        {
            TimeToProcess = rnd.Next(3000);
            Name = Guid.NewGuid().ToString();
        }
        public Cashier(int num)
        {
            this.TimeToProcess = rnd.Next(3000);
            this.Name = $"#{num}";
        }

    }
}

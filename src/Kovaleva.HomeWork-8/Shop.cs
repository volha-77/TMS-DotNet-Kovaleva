using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace TMS.ShopSimulator
{
    internal class Shop
    {
        private PeopleGenerator peopleGenerator;
        private Queue<Person> processingQueue;
        //private List<Thread> processors;
        private bool isOpen;
        private ManualResetEventSlim peopleSynchronisator;
        private Queue<Cashier> CashierQueue;
        private List<Cashier> allCashier;
        private ManualResetEventSlim shopSynchronisator;

        public Shop(PeopleGenerator peopleGenerator, int cashierNumber)
        {
            this.peopleGenerator = peopleGenerator;
            this.processingQueue = new Queue<Person>();
            this.peopleSynchronisator = new ManualResetEventSlim();
            this.shopSynchronisator = new ManualResetEventSlim();
            this.CashierQueue = new Queue<Cashier>();

            var processors = new List<Thread>();
            var allCashier = new List<Cashier>();
            for (int i = 0; i < cashierNumber; i++)
            {
                processors.Add(new Thread(ProcessPeople));
                allCashier.Add(new Cashier());
            }
          //  this.processors = processors;
            this.allCashier = allCashier;

        }

        internal void Open()
        {
            Console.WriteLine("Shop is opening...");
            isOpen = true;
            //for (int i = 1; i <= processors.Count; i++)
            for (int i = 1; i <= allCashier.Count; i++)
            {
                // processors[i - 1].Start();
                ThreadPool.QueueUserWorkItem(ProcessPeople);
                EnqueueCashier(allCashier[i-1]);
                Console.WriteLine($"Cachier {allCashier[i-1].Name} is opened.");
            }
        }

        internal void Close()
        {
            isOpen = false;
            peopleSynchronisator.Set();
            shopSynchronisator.Wait(); 
        }

        internal void EnterShop()
        {
            lock (processingQueue)
            { processingQueue.Enqueue(peopleGenerator.GetPerson()); }

            peopleSynchronisator.Set();
        }

        private bool TryDequeuePerson(out Person person)
        {
            person = null;
            lock (processingQueue) {
                if (this.processingQueue.Count > 0)
                {
                    person = processingQueue.Dequeue();
                    return true;
                }
                return false;
            }
         }

        private void ProcessPeople(object obj)
        {
            while (isOpen)
            {
                //while (!(this.processingQueue.Count > 0))
                //{
                while (TryDequeueCashier(out var cashier))
                {
                    while (TryDequeuePerson(out var person))
                    {
                        //Thread.Sleep(100);
                        int TimeToProcess = person.TimeToProcess + cashier.TimeToProcess;
                        Console.WriteLine($"Cachier {cashier.Name} is processing {person.Name} on thread {Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(person.TimeToProcess);
                        //Console.WriteLine($"Cachier {obj} is processed {person.Name}.");
                    }


                    //}
                    if (isOpen) 
                    { 
                        EnqueueCashier(cashier);
                        this.peopleSynchronisator.Reset();
                        this.peopleSynchronisator.Wait();
                    }
                  
                }
               
            }
            shopSynchronisator.Set();
            Console.WriteLine($"Cachier {Thread.CurrentThread.ManagedThreadId} is exitting.");
        }

        private void EnqueueCashier(Cashier cashier)
        {
            lock (CashierQueue)
            { CashierQueue.Enqueue(cashier);
            }
        }

        private bool TryDequeueCashier(out Cashier cashier)
        {
            cashier = null;
            lock (CashierQueue)
            {
                if (this.CashierQueue.Count > 0)
                {
                    cashier = CashierQueue.Dequeue();
                    return true;
                }
                return false;
            }
        }
    }
}
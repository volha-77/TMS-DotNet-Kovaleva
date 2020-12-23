using System;
using System.Collections.Generic;

namespace Kovaleva.HomeWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static List<Task> InitTaskList()
        {
            var TaskList = new List<Task>();
            bool toInput = true; 
            do
            {
                Console.WriteLine("Input name of the Task:");
                string name = Console.ReadLine();

                Console.WriteLine("Input description of the Task:");
                string description = Console.ReadLine();

                Console.WriteLine("Input start date of the Task:");
                string startDate = Console.ReadLine();

                Console.WriteLine("Input end date of the Task:");
                string endDate = Console.ReadLine();

                Task myTask = new Task(name, description, startDate, endDate);

                Console.WriteLine("Input status of the Task (InProcess, ToDo, IsDone):");
                myTask.ChangeProperty("status", Console.ReadLine());

                Console.WriteLine("If you want to continue input Task, press Y, else press N");
                toInput = Console.ReadLine() == "Y" ? true : false;
            } while (toInput);
           
           
            return TaskList;
        }
    }

  
}

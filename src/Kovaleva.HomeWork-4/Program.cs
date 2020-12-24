using System;
using System.Collections.Generic;

namespace Kovaleva.HomeWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var TaskList = InitTaskList();

            PrintTaskList(TaskList);
           
            Console.WriteLine("");
            bool toInput = true;
            do
            {
                Console.WriteLine("Choose operation:");
                Console.WriteLine("=========");
                Console.WriteLine("Add task press \"A\"");
                Console.WriteLine("Delete task press \"D\"");
                Console.WriteLine("Edit task press \"E\"");
                Console.WriteLine("Quit \"Q\"");

                Console.WriteLine();
                string inputResult = Console.ReadLine().ToUpper();
                switch (inputResult)
                {
                    case "A":
                        AddTask(TaskList);
                        break;
                    case "D":
                        DeleteTask(TaskList);
                        break;
                    case "E":
                        EditTask(TaskList);
                        break;

                    default:
                        toInput = false;
                        break;
                }
            }
            while (toInput);

            Console.WriteLine();
            PrintTaskList(TaskList);
        }

        private static List<Task> InitTaskList()
        {
            var TaskList = new List<Task>();
            bool toInput = true;
            do
            {
                AddTask(TaskList);

                Console.WriteLine("If you want to continue input Task, press Y, else press N");
                toInput = Console.ReadLine().ToUpper() == "Y" ? true : false;
            } while (toInput);


            return TaskList;
        }

        private static void AddTask(List<Task> TaskList)
        {
            Console.WriteLine("Now create the Task.");
            Console.WriteLine("Input name of the Task:");
            string name = Console.ReadLine();

            Console.WriteLine("Input description of the Task:");
            string description = Console.ReadLine();

            Console.WriteLine("Input start date of the Task:");
            string startDate = Console.ReadLine();

            Console.WriteLine("Input end date of the Task:");
            string endDate = Console.ReadLine();
            Task myTask = null;

            try
            {
                myTask = new Task(name, description, startDate, endDate);
            }
            catch (Exception)
            {

            }

            if (myTask != null)
            {
                Console.WriteLine("Input status of the Task (InProcess, ToDo, IsDone):");
                myTask.ChangeProperty("status", Console.ReadLine());
                TaskList.Add(myTask);
            }
        }

        private static void EditTask(List<Task> TaskList)
        {
            Console.WriteLine("Input Task ID:");
            string taskId = Console.ReadLine().ToUpper().Trim();

            foreach (var myTask in TaskList)
            {
                if (myTask.GetId().ToUpper() == taskId)

                {
                    string propName = Console.ReadLine();
                    string value = Console.ReadLine();
                    myTask.ChangeProperty(propName, value);
                }
            }

        }

        private static void DeleteTask(List<Task> TaskList)
        {
            Console.WriteLine("Input Task ID:");
            string taskId = Console.ReadLine().ToUpper().Trim();

            foreach (var myTask in TaskList)
            {
                if (myTask.GetId().ToUpper() == taskId)

                {
                    TaskList.Remove(myTask);
                }
            }

        }

        private static void PrintTaskList(List<Task> TaskList)
        {
            Console.WriteLine("=========");
            Console.WriteLine("Task list");
            Console.WriteLine("=========");
            foreach (var myTask in TaskList)
            {
                myTask.PrintInfo();
            }
        }
    }

}

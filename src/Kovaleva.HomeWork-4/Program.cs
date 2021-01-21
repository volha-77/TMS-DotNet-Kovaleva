using System;
using System.Collections.Generic;

namespace Kovaleva.HomeWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskList = InitTaskList();

            PrintTaskList(taskList);
           
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
                        AddTask(taskList);
                        break;
                    case "D":
                        DeleteTask(taskList);
                        break;
                    case "E":
                        EditTask(taskList);
                        break;

                    default:
                        toInput = false;
                        break;
                }
            }
            while (toInput);

            Console.WriteLine();
            PrintTaskList(taskList);
        }

        private static List<Task> InitTaskList()
        {
            var taskList = new List<Task>();
            bool toInput = true;
            do
            {
                AddTask(taskList);

                Console.WriteLine("If you want to continue input Task, press Y, else press N");
                toInput = Console.ReadLine().ToUpper() == "Y" ? true : false;
            } while (toInput);


            return taskList;
        }

        private static void AddTask(List<Task> taskList)
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
                taskList.Add(myTask);
            }
        }

        private static void EditTask(List<Task> taskList)
        {
            Console.WriteLine("Input Task ID:");
            string taskId = Console.ReadLine().ToUpper().Trim();

            foreach (var myTask in taskList)
            {
                if (myTask.Id.ToUpper() == taskId)

                {
                    Console.WriteLine("Input property name:");
                    string propName = Console.ReadLine();
                    Console.WriteLine("Input property value:");
                    string value = Console.ReadLine();
                    myTask.ChangeProperty(propName, value);
                }
            }

        }

        private static void DeleteTask(List<Task> taskList)
        {
            Console.WriteLine("Input Task ID:");
            string taskId = Console.ReadLine().ToUpper().Trim();

            foreach (var myTask in taskList)
            {
                if (myTask.Id.ToUpper() == taskId)

                {
                    taskList.Remove(myTask);
                }
            }

        }

        private static void PrintTaskList(List<Task> taskList)
        {
            Console.WriteLine("=========");
            Console.WriteLine("Task list");
            Console.WriteLine("=========");
            foreach (var myTask in taskList)
            {
                myTask.PrintInfo();
            }
        }
    }

}

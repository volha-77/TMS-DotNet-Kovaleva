using System;

namespace Kovaleva.HomeWork_4
{
    public class Task
    {
        private readonly string Id;

        private string GetId()
        { return Guid.NewGuid().ToString().ToUpper().Substring(0, 5); }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Task()
        {
            Id = GetId();

        }

        public Task(string name, string description, DateTime startDate, DateTime endDate)
        {
            Id = GetId();
            Name = name;
            Description = description;

            StartDate = startDate;
            EndDate = endDate;
        }

        public void PrintInfo()
        { 
            Console.WriteLine(Id);
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine($"{StartDate.ToShortDateString()} -> {EndDate.ToShortDateString()}");

        }

        public void ChangeProperty(string property, string value)
        {
            property = property.ToLower();
            switch (property)
            {
                case "name":
                    Name = value;
                    break;
                case "description":
                    Description = value;
                    break;
                case "startDate":
                    StartDate = DateTime.Parse(value);
                    break;
                case "endDate":
                    EndDate = DateTime.Parse(value);
                    break;
            }
        }

    }
}

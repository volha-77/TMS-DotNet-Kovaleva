using System;

namespace Kovaleva.HomeWork_4
{
    public class Task
    {
        private readonly string Id;
        private DateTime startDate;
        private DateTime endDate;
        private string GetId()
        { return Guid.NewGuid().ToString().ToUpper().Substring(0, 5); }

        private DateTime ConvertDateFromString(string value)
        {
            DateTime result;
            try
            {
                result = DateTime.Parse(value);
            }
            catch (Exception)
            {
                result = DateTime.Now;
                Console.WriteLine("Error! You've set wrong date. Date will be set on Now.");
                // throw;
            }
            return result;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public string StartDate
        {
            get { return startDate.ToShortDateString(); }
            set => startDate = ConvertDateFromString(value);
        }

        public string EndDate
        {
            get { return endDate.ToShortDateString(); }
            set => endDate = ConvertDateFromString(value);
        }

        public Task()
        {
            Id = GetId();

        }

        public Task(string name, string description, string startDate, string endDate)
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
            Console.WriteLine($"{startDate.ToShortDateString()} -> {endDate.ToShortDateString()}");

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
                      StartDate = value;
                    break;
                case "endDate":
                    EndDate = value;
                    break;
            }
        }

    }
}

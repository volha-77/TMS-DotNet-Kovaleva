using System;

namespace Kovaleva.HomeWork_4
{
    public class Task
    {
        private readonly string Id;
        private DateTime _startDate;
        private DateTime _endDate;
        private TaskStatus _status;
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
            get { return _startDate.ToShortDateString(); }
            set => _startDate = ConvertDateFromString(value);
        }

        public string EndDate
        {
            get { return _endDate.ToShortDateString(); }
            set => _endDate = ConvertDateFromString(value);
        }

        public Task()
        {
            Id = GetId();
            _status = TaskStatus.ToDo;
        }

        public Task(string name, string description, string startDate, string endDate)
        {
            Id = GetId();
            Name = name;
            Description = description;

            StartDate = startDate;
            EndDate = endDate;
            _status = TaskStatus.ToDo;

            if (_startDate > _endDate)
            {
                throw new Exception("Error! You've input the start date greater than the end date!");
            }

        }

        public void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Dates: {_startDate.ToShortDateString()} -> {_endDate.ToShortDateString()}");
            Console.WriteLine($"status: {_status}");

        }

        public bool ChangeProperty(string property, string value)
        {
            bool result = true;
            property = property.ToLower();
            switch (property)
            {
                case "name":
                    Name = value;
                    break;
                case "description":
                    Description = value;
                    break;
                case "startdate":
                    StartDate = value;
                    break;
                case "enddate":
                    EndDate = value;
                    break;
                case "status":
                    
                    for (int i = 1; i <= Enum.GetNames(typeof(TaskStatus)).Length; i++)
                    {
                        result = false;
                        var status = (TaskStatus)i;
                        if (status.ToString().ToUpper() == value.ToUpper().Trim())
                        {
                            _status = status;
                            result = true;
                            break;
                        }
                    }
                    if (!result)
                    {
                        Console.WriteLine("You input wrong status!");
                      _status = TaskStatus.Unknown;
                    }

                    break;
            }
            return result;
        }

    }
}

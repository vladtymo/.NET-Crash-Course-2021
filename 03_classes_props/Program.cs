using System;

namespace _03_classes_props
{
    partial class Worker //: object // all your own classes auto inherit the base object class
    {
        // Fields
        private static decimal minSalary = 6000;

        private readonly DateTime birthDate;    // can initialize and set in constructors
        private const int tax = 340;            // can initialize only

        //public DateTime BirthDate { get; set; }        // can set from anywhere
        //public DateTime BirthDate { get; private set } // can set only inside this class
        //public DateTime BirthDate { get; }             // can set only in constructors (readonly)

        // Properties
        // full property (snippet: propfull)
        private decimal salary;
        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                // value - new value for the parameter
                
                //if (value >= minSalary)
                //    salary = value;
                //else
                //    salary = minSalary;

                salary = (value >= minSalary ? value : minSalary);
            }
        }

        //private string firstName;
        //public string FirstName { get => firstName; set => firstName = value; }

        // Auto-property (snippet: prop)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        // property with get only
        //public string FullName { get => $"{FirstName} {LastName}"; }
        public string FullName => $"{FirstName} {LastName}";
        public decimal PureSalary => Salary - tax;

        // Constructors
        // default constructor
        public Worker() { }
        public Worker(string fName, string lName, DateTime bDate)
        {
            FirstName = fName;
            LastName = lName;
            birthDate = bDate;

            salary = minSalary;
        }
        public Worker(string fName, string lName, DateTime bDate, decimal salary) : this(fName, lName, bDate)
        {
            //if (salary >= minSalary)
            //    this.salary = salary;
            //else
            //    this.salary = minSalary;

            //SetSalary(salary);

            Salary = salary;
        }

        // setter & getter
        //public void SetSalary(decimal value)
        //{
        //    if (value >= minSalary)
        //        this.salary = value;
        //    else
        //        this.salary = minSalary;
        //}
        //public decimal GetSalary()
        //{
        //    return salary;
        //}
        //public string GetFullName()
        //{
        //    return $"{FirstName} {LastName}";
        //}

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ctrl + K + C - comment selected text
            // Ctrl + K + U - uncomment selected text
            Console.OutputEncoding = System.Text.Encoding.UTF8;
         
            Worker admin = new Worker();
            Worker worker = new Worker("Vova", "Lublin", new DateTime(1990, 2, 5), 7500);
            worker.Show();

            //worker.SetSalary(9900);                                   // method set
            //Console.WriteLine($"Salary: {worker.GetSalary()} UAH");   // method get

            worker.Salary = 12050;                              // property set 
            Console.WriteLine($"Salary: {worker.Salary} UAH");  // property get

            //Console.WriteLine($"Full Name: {worker.FirstName} {worker.LastName}");
            Console.WriteLine($"Full Name: {worker.FullName}");
            Console.WriteLine($"Pure Salary: {worker.PureSalary} UAH");

            //Console.WriteLine(worker.ToString()); // get full class name by default
            Console.WriteLine(worker);
        }
    }
}

using System;

namespace _03_classes_props
{
    partial class Worker
    {
        public void Show()
        {
            Console.WriteLine($"{FirstName} {LastName} : {birthDate.ToLongDateString()}");
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} : {birthDate.ToLongDateString()}";
        }
    }
}

using System;

namespace _07_interfaces
{
    public interface IWorkable
    {
        // public by default for all members

        // methods
        void DoWork();

        // properties
        bool IsWorking { get; set; }
        decimal Salary { get; init; }

        // static, const fields
        //public static decimal minSalary = 6000;
        //public const float tax = 20;

        // event, delegates
    }


    class Seller : IWorkable // realize (implenent) the interface
    {
        public bool IsWorking { get; set; }
        public decimal Salary { get; init; }
        public void DoWork()
        {
            Console.WriteLine("Sell some products!");
        }
    }
    class Cashier : IWorkable
    {
        public bool IsWorking { get; set; }
        public decimal Salary { get; init; }
        public void DoWork()
        {
            Console.WriteLine("Get payment from customers!");
        }
    }

    // Interface Inheritance
    interface A
    {
        void ShowA();
    }
    interface B
    {
        void ShowB();
    }
    interface C : A, B
    {
        void ShowC();
    }

    class SuperClass : C
    {
        public void ShowA()
        {
            throw new NotImplementedException();
        }

        public void ShowB()
        {
            throw new NotImplementedException();
        }

        public void ShowC()
        {
            throw new NotImplementedException();
        }
    }

    // Hides Interface Members
    interface IPrintable
    {
        //...
        void Print();
    }
    interface IDrawable
    {
        void Print();
    }
    interface IShowable
    {
        void Print();
    }
    class Shape : IPrintable, IShowable, IDrawable
    {
        public void Print()
        {
            Console.WriteLine("Shape is printing!");
        }
        void IShowable.Print()
        {
            Console.WriteLine("Shape is showing!");
        }
        void IDrawable.Print()
        {
            Console.WriteLine("Shape is drawing!");
        }
    }



    class Program
    {
        static void Test(IWorkable worker)
        {
            if (worker.IsWorking)
                worker.DoWork();
            else
                Console.WriteLine("This worker currently is free!");
        }

        static void Main(string[] args)
        {
            //Seller seller = new Seller()
            //{
            //    Salary = 2300,
            //    IsWorking = true
            //};
            //Cashier cahier = new Cashier
            //{
            //    Salary = 2500,
            //    IsWorking = false
            //};

            //IWorkable worker = cahier;

            //Test(seller);
            //Test(cahier);

            // Hides Interface Members
            Shape shape = new Shape();

            shape.Print();

            IDrawable drawable = shape;
            drawable.Print();

            IShowable showable = shape;
            showable.Print();

            IPrintable printable = shape;
            printable.Print();
        }
    }
}

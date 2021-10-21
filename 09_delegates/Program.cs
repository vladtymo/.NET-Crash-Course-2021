using System;

namespace _09_delegates
{
    class Helper
    {
        public static void VoidStaticMethod()
        {
            Console.WriteLine("I am void static method!");
        }
        public void VoidMethod()
        {
            Console.WriteLine("I am void method!");
        }
        public void MethodWithParams(string str)
        {
            Console.WriteLine("String param: " + str);
        }
    }

    // delegate return_type DelegateName(input params);
    public delegate void VoidDelegate();
    public delegate void DelegateWithParam(string str);

    public delegate int ModifyDelegate(int value);

    class Program
    {
        static int Pow(int value)
        {
            return value * value;
        }
        static int Increment(int value)
        {
            return value + 1;
        }

        static void ModifyArray(int[] arr, ModifyDelegate algo)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                // modify algorithm
                arr[i] = algo(arr[i]);
            }
        }

        static void Main(string[] args)
        {
            //Helper.VoidStaticMethod();
            //Helper helper = new Helper();
            //helper.VoidMethod();

            //VoidDelegate del = new VoidDelegate(Helper.VoidStaticMethod);

            //del?.Invoke(); // NullReferenceEx
            //del();

            //del = helper.VoidMethod;
            //del();

            //DelegateWithParam del2 = helper.MethodWithParams;
            //del2("Hello delegate!");

            int[] numbers = new int[10] { 4, 2, 6, -5, 7, 9, 0, -1, 3, 9 };

            ModifyArray(numbers, Increment);
            ModifyArray(numbers, Pow);
            ModifyArray(numbers, delegate (int value) { return value * -1; });  // anonymous delegate
            ModifyArray(numbers, (value) => value * -1);                        // anonymous lambda expression

            foreach (var n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
    }
}

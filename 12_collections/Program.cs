using System;
using System.Collections; // non-generic collections
using System.Collections.Generic; // generic collections

namespace _12_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////// Non-generic collections
            ///// ArrayList

            ArrayList arrayList = new ArrayList();

            arrayList.Add(55);  // boxing
            arrayList.Add(2.5);
            arrayList.Add(37);
            arrayList.Add("Hello");

            foreach (object item in arrayList)
            {
                if (item is int) //item.GetType() == typeof(int))
                {
                    int intVar = (int)item; // unboxing
                    Console.Write("Int: ");
                }
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //////////// Generic collections
            /////// List

            List<int> list = new List<int>(50); // initial capacity = 50

            // Add
            list.Add(12); // without boxing
            list.Add(99);
            list.Add(45);
            list.AddRange(new int[] { 3, 4, 5 });

            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count: " + list.Count);

            foreach (var item in list)
            {
                int intVar = item; // without unboxing
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Remove
            list.RemoveAt(0);

            if (list.Contains(4))
                Console.WriteLine("Element 4 is exist!");
            list.Remove(4);

            PrintCollection(list);

            list.Clear();

            ///////////// Stack - LIFO (Last In First Out)

            Stack<string> stack = new Stack<string>();

            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");

            string top = stack.Peek(); // get element without removing
            Console.WriteLine("Top: " + top);

            while (stack.Count > 0)
            {
                Console.WriteLine("Element: " + stack.Pop()); // get with removing
            }

            /////////// Queue - FIFO (First In First Out)

            Queue<string> queue = new Queue<string>();

            queue.Enqueue("Vova");
            queue.Enqueue("Olga");
            queue.Enqueue("Igor");
            queue.Enqueue("Alex");

            string first = queue.Peek(); // get element without removing
            Console.WriteLine("First: " + first);

            while (queue.Count > 0)
            {
                Console.WriteLine("Element: " + queue.Dequeue()); // get with removing
            }

            //////////// Dictionary
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Language", "Мова");
            dictionary.Add("Call", "Називати, телефонувати, викликати");
            dictionary.Add("Speak", "Говорити, розмовляти");

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            dictionary["Speak"] += ", балакати";

            string value = dictionary["Speak"];
            Console.WriteLine(value);

            Dictionary<string, Car> cars = new Dictionary<string, Car>()
            {
                ["ВК4545ОА"] = new Car() { Model = "Nissan Note", Year = 2012 },
                ["АС9899АП"] = new Car() { Model = "Ford Focus", Year = 2016 },
                ["ВК0101ВВ"] = new Car() { Model = "BMW X6", Year = 2019 }
            };

            //cars.Add("AC7777АР", new Car() { Model = "Subaru Impreza", Year = 2010 });
            cars["AC7777АР"] = new Car() { Model = "Subaru Impreza", Year = 2010 };

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("Model: " + cars["ВК0101ВВ"].Model);
            cars.Remove("ВК0101ВВ");

            if (cars.ContainsKey("ВК0101ВВ"))
                Console.WriteLine("Is Exists!");
            else
                Console.WriteLine("Is not Exists!");
        }

        class Car
        {
            public string Model { get; set; }
            public int Year { get; set; }
            public override string ToString()
            {
                return $"{Model} {Year} year";
            }
        }

        static void PrintCollection<T>(IEnumerable<T> colleciton)
        {
            foreach (var item in colleciton)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

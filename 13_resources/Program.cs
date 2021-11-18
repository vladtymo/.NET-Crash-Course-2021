using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace _13_resources
{
    class Program
    {
        static void MakeGarbage()
        {
            for (int i = 0; i < 100_000; i++)
            {
                Person p = new Person();
            }
        }
        static void Main(string[] args)
        {
            // Managed / Unmanaged Resources

            if (true)
            {
                Random rnd = new Random();
                //... reachable
                rnd.Next();
            }

            string str = "bla";
            //... unreachable
            str.ToString();

            // GC - Garbage Collector
            Console.WriteLine("Total memory: " + GC.GetTotalMemory(false));

            MakeGarbage();

            Console.WriteLine("Total memory: " + GC.GetTotalMemory(false)); // 5......
            Console.WriteLine("Str generation: " + GC.GetGeneration(str));  // 0

            GC.Collect();

            Console.WriteLine("Total memory: " + GC.GetTotalMemory(false)); // ...
            Console.WriteLine("Str generation: " + GC.GetGeneration(str));  // 1

            // Unmanaged Resources
            using (MyFile f = new MyFile())
            {
                Console.WriteLine("Resource is " + (f.IsResourceExists ? "exists" : "not exists"));
                //... using the file

            } // f.Dispose();


            //FileStream fs = null;
            //try
            //{
            //    fs = new FileStream("test.txt", FileMode.Create);
            //    //fs.Write();
            //    int.Parse("blabla");
            //    //fs.Read();
            //}
            //finally
            //{
            //    fs.Dispose();
            //}

            Person person = new Person()
            {
                FirstName = "Vlad",
                LastName = "Graegaerg",
                Salary = 2000,
                Birthdate = new DateTime(1990, 1, 1)
            };

            // Serializer: Binary, XML, SOAP, JSON
            // Binary
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream fs = new FileStream("test.bin", FileMode.Create))
            {
                serializer.Serialize(fs, person);
            }

            // JSON
            File.WriteAllText("person.json", JsonSerializer.Serialize(person));

            // Deserialize
            using (FileStream fs = new FileStream("test.bin", FileMode.Open))
            {
                var p = (Person)serializer.Deserialize(fs);
                Console.WriteLine(p);
            }

            //.............
            Console.ReadKey();
        }
    }
    class MyFile : IDisposable
    {
        public bool IsResourceExists { get; set; }
        public MyFile()
        {
            Console.WriteLine("Create the resources!");
            IsResourceExists = true;
        }

        // Finalizer
        ~MyFile()
        {
            Console.WriteLine("Clear the resources!");
            IsResourceExists = false;
        }

        public void Dispose()
        {
            Console.WriteLine("Clear the resources!");
            IsResourceExists = false;

            GC.SuppressFinalize(this);
        }
    }

    [Serializable] // metadata
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthdate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Salary}$ {Birthdate.ToShortDateString()}";
        }
    }
}

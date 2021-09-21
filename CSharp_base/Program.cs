using System;

namespace CSharp_base
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            #region Data Types
            ////////// data types
            //// value-type: structures (int, char, bool, decimal...) 
            ////      in stack, non-nullable
            //// reference-type: classes (string, object, Array...), interfaces, delegates
            ////      in heap, nullable

            //int a = 10;
            //string str = "hello";

            //Console.WriteLine(a + ", " + str);

            ////float koef = null;
            //string name = null;

            //if (name != null)
            //{
            //    name.ToLower();
            //}
            //// null-conditional
            //name?.ToLower();

            //Console.WriteLine("Length: " + name?.Length);
            //Console.WriteLine("Contains 'a':" + name?.Contains('a'));

            //// nullable structure
            ////Nullable<decimal> price = null;
            //decimal? price = null;

            //Console.Write("Enter a number: ");
            //price = decimal.Parse(Console.ReadLine());

            //Console.WriteLine($"Price: {price}UAH"); // interpolation
            #endregion

            //////////////////// string class
            string line = "How are you? Yes, No.";
            string word = "you";

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i])) { }
            }
            Console.WriteLine("Symbols: " + line.Length);
            Console.WriteLine("Line contains the word: " + line.Contains(word));

            Console.WriteLine("Index of the word: " + line.IndexOf(word));
            Console.WriteLine($"First 'o' at {line.IndexOf('o')}");
            Console.WriteLine($"Last 'o' at {line.LastIndexOf('o')}");

            Console.WriteLine("Removed after index 7: " + line.Remove(7));

            string[] words = line.Split(new char[] { ',', '.', '!', ' ', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string w in words)
            {
                Console.WriteLine("Word: " + w);
            }

            Console.WriteLine("Joined: " + string.Join(" - ", words));

            string email = " blabla@csharp.net       ";
            Console.WriteLine($"Trimmed: '{email.Trim()}'"); // ' ', '\t', '\n'
        }
    }
}

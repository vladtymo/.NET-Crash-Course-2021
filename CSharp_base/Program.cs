using System;

namespace CSharp_base
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Data Types
            //////// data types
            // value-type: structures (int, char, bool, decimal...) 
            //      in stack, non-nullable
            // reference-type: classes (string, object, Array...), interfaces, delegates
            //      in heap, nullable

            int a = 10;
            string str = "hello";

            Console.WriteLine(a + ", " + str);

            //float koef = null;
            string name = null;

            if (name != null)
            {
                name.ToLower();
            }
            // null-conditional
            name?.ToLower();

            Console.WriteLine("Length: " + name?.Length);
            Console.WriteLine("Contains 'a':" + name?.Contains('a'));

            // nullable structure
            //Nullable<decimal> price = null;
            decimal? price = null;

            Console.Write("Enter a number: ");
            price = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"Price: {price}UAH"); // interpolation
            #endregion

            #region string class
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
            #endregion

            #region Array
            int[] arr = new int[10];

            Console.WriteLine("Length: " + arr.Length);

            arr[0] = 666;       // arr.SetValue(777, 1);
            var first = arr[0]; // arr.GetValue(1);

            foreach (var item in arr)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            int[] array2 = new int[] { 11, 22, 33, 44, 55 };

            int[] array3 = new int[20];

            Random rnd = new Random();
            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = rnd.Next(100);
            }

            // readonly item
            foreach (var item in array3) // collection must implement IEnumerable interface
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            array2.CopyTo(array3, 5);

            PrintArray("After copy: ", array3);

            int[] copy = (int[])array3.Clone(); // deep copy
            //int[] copy = array3;              // shallow copy

            array3[0] = 99;
            Console.WriteLine("The first element in copy: " + copy[0]);

            Array.Sort(array3);
            PrintArray("Sorted: ", array3);

            Console.WriteLine($"Found index: {Array.IndexOf(array3, 44)}");
            Console.WriteLine($"Found index (binary search): {Array.BinarySearch(array3, 44)}");

            Array.Reverse(array3);
            PrintArray("Reversed: ", array3);

            ChangeArray(array3);
            PrintArray("Changed: ", array3);

            Array.Resize(ref array3, 10);
            PrintArray("Resized: ", array3);
            #endregion

            #region Multi-Dimension Array
            int[,] matrix = new int[4, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 }
            };

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($"{matrix[r, c]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Upper bound (rows): " + matrix.GetUpperBound(0));
            Console.WriteLine("Upper bound (columns): " + matrix.GetUpperBound(1));
            #endregion

            #region Jugged Array
            int[][] jugged = new int[3][];

            jugged[0] = new int[7];
            jugged[1] = new int[3];
            jugged[2] = new int[5];

            foreach (int[] arrItem in jugged)
            {
                foreach (var i in arrItem)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            #endregion
        }

        static void ChangeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
        }
        static void PrintArray(string title, int[] array)
        {
            Console.WriteLine(title);
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}

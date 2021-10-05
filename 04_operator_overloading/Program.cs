using System;

namespace _04_operator_overloading
{
    class Cattle : object
    {
        private float volume;

        public float Volume
        {
            get { return volume; }
            set
            {
                volume = (value >= 0) ? value : 0;
            }
        }

        public float liquidVolume;
        public float LiquidVolume
        {
            get { return liquidVolume; }
            set
            {
                if (value < 0) liquidVolume = 0;
                else if (value > volume) liquidVolume = volume;
                else liquidVolume = value;
            }
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Model} {Color} cattle with {Volume} litters");
        }

        ////////// Overloaded Operators
        // public static return_type operator symbol(parameters) { ... }

        // Unary operators ???
        public static Cattle operator ++(Cattle cattle)
        {
            cattle.Volume += 0.1F;
            return cattle;
        }
        public static Cattle operator --(Cattle cattle)
        {
            cattle.Volume -= 0.1F;
            return cattle;
        }

        // Binary Operators
        public static Cattle operator +(Cattle left, Cattle right)
        {
            return new Cattle()
            {
                Model = left.Model,
                Color = left.Color,
                Volume = left.Volume + right.Volume
            };
        }
        public static Cattle operator +(Cattle left, int volume)
        {
            return new Cattle()
            {
                Model = left.Model,
                Color = left.Color,
                Volume = left.Volume + volume
            };
        }

        public static Cattle operator -(Cattle left, Cattle right)
        {
            return new Cattle()
            {
                Model = left.Model,
                Color = left.Color,
                Volume = left.Volume - right.Volume
            };
        }

        // Logic Operators - [> < >= <=]
        public static bool operator>(Cattle left, Cattle right)
        {
            return left.Volume > right.Volume;
        }
        public static bool operator <(Cattle left, Cattle right)
        {
            return !(left > right);
        }

        // Equals Operators
        public override bool Equals(object obj)
        {
            return obj is Cattle cattle &&
                   Volume == cattle.Volume;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Volume);
        }

        public static bool operator ==(Cattle left, Cattle right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Cattle left, Cattle right)
        {
            return !(left == right);
        }

        // True/False operators
        public static bool operator true(Cattle cattle)
        {
            return cattle.LiquidVolume > 0;
        }
        public static bool operator false(Cattle cattle)
        {
            return cattle.LiquidVolume == 0;
        }

        // Type Conversin Operators
        public static explicit operator float(Cattle cattle)
        {
            return cattle.Volume;
        }
        public static implicit operator string(Cattle cattle)
        {
            return $"{cattle.Model} {cattle.Color}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 7;
            int c = a + b;
            int d = ++c;

            Cattle c1 = new Cattle()
            {
                Model = "Saturn",
                Volume = 1.5F,
                Color = "Red"
            };
            Cattle c2 = new Cattle()
            {
                Model = "Apple",
                Volume = 2.3F,
                Color = "White"
            };

            ++c1;
            c1.Print();

            //Cattle c3 = c1 + c2;
            Cattle c3 = c1 + 3;

            c3.Print();

            if (c1 > c2)
                Console.WriteLine("c1 Bigger than c2");
            else
                Console.WriteLine("c1 Not Bigger than c2");

            c1.LiquidVolume = 0.8F;
            if (c1)
                Console.WriteLine("Cattle is not empty!");
            else
                Console.WriteLine("Cattle is empty!");

            // Type Conversions
            int intVar = 5;
            float doubleVar = 3.8F;

            doubleVar = intVar;         // implicit
            intVar = (int)doubleVar;    // explicit

            string str = c1;
            doubleVar = (float)c1;

            Console.WriteLine("Str: " + str);
            Console.WriteLine($"Double: {doubleVar}");

        }
    }
}

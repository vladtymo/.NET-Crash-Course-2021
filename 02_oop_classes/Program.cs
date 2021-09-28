using System;

namespace _02_oop_classes
{
    // OOP - Object Oriented Programming
    // 1 - Incapsulation
    // 2 - Inheritance
    // 3 - Polymorphism
    // 4 - Abstraction (additional)

    // Access Specificators:
    // * private - can access only from class (by default)
    // * public - can access from everywhere
    class Conditioner
    {
        // ----------- Fields (parameters) -----------
        private string model;
        private float temperature;
        private uint mode; // 0-auto 1-cool, 2-warm, 3-dry
        private bool isPowerOn; 

        private float minT, maxT;

        // ----------- Constructors -----------
        public Conditioner()
        {
            // auto initialize: false, 0, null
            model = "no model";
            minT = 16;
            maxT = 34;
            temperature = minT;
        }
        public Conditioner(string model, float minT, float maxT)
        {
            this.model = model;

            if (minT > maxT)
            {
                float tmp = minT;
                minT = maxT;
                maxT = tmp;
            }
            this.minT = minT;
            this.maxT = maxT;
            temperature = minT;
        }
        public Conditioner(string model, float minT, float maxT, uint mode) : this(model, minT, maxT)
        {
            // additional code
            this.mode = mode;
        }

        // ----------- Methods (functions) -----------
        // getter - get the value of some field
        public float GetTemperature()
        {
            return temperature;
        }
        // setter - set the value to the class parameter
        public void SetMode(uint mode)
        {
            if (mode >= 0 && mode <= 3)
                this.mode = mode;
        }

        public void SwitchPower()
        {
            isPowerOn = !isPowerOn;
        }
        public void IncreaseT()
        {
            if (temperature < maxT)
                temperature += 0.5F;
        }
        public void DecreaseT()
        {
            if (temperature > minT)
                temperature -= 0.5F;
        }

        public void ShowInfo()
        {
            Console.Write($":AC {model}\n" +
                $"T: [{minT} ... {temperature} ... {maxT}]\n" +
                $"Mode: ");
            switch (mode)
            {
                case 0: Console.Write("Auto"); break;
                case 1: Console.Write("Cool"); break;
                case 2: Console.Write("Warm"); break;
                case 3: Console.Write("Dry"); break;
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Conditioner ac1 = new Conditioner();
            Conditioner ac2 = new Conditioner("LG", 18, 36);
            Conditioner ac = new Conditioner("Samsung", 14, 38, 3);

            ac.IncreaseT();
            ac.IncreaseT();
            ac.IncreaseT();

            ac.SetMode(1);

            Console.WriteLine($"Current Temperature: {ac.GetTemperature()} C");
            ac.ShowInfo();
        }
    }
}

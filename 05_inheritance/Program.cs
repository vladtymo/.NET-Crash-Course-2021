using System;

namespace _05_inheritance
{
    class Device
    {
        protected bool isOn; // can access from derived classes

        public string Model { get; set; }
        public int SerialNumber { get; set; }
        public DateTime ManufactureDate { get; }

        public string Status => "Power " + (isOn ? "ON" : "OFF");

        static int count = 123456;

        public Device()
        {
            Model = "No model";
            SerialNumber = count++;
            ManufactureDate = DateTime.UtcNow;
        }
        public Device(string m) : this()
        {
            Model = m;
        }

        public void SwitchPower()
        {
            isOn = !isOn;
        }
        public void PrintInfo()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Device: {Model} : {SerialNumber}\n" +
                $"Manufacture Date: {ManufactureDate.ToShortDateString()}\n" +
                $"Status: {Status}");
        }
    }

    // Inheritance: class : base_class, Interface1, Interface2 ...
    class Monitor : Device
    {
        public string Resolution { get; set; }
        public int Frequency { get; set; }

        public Monitor() : base()
        {
            Resolution = "No setted";
        }
        public Monitor(string m, string r, int f) : base(m)
        {
            Resolution = r;
            Frequency = f;
        }

        public void DisplayPicture()
        {
            if (isOn)
                Console.WriteLine("I am displaying a picture!");
            else
                Console.WriteLine("Please turn the monitor on to display!");
        }
        // new - exclicit hide the inherited member
        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Resolution: {Resolution}\n" +
                $"Frequency: {Frequency}Hz");
        }
    }

    class TV : Monitor
    {
        public int Channels { get; set; }
        public int CurrentChannel { get; set; }

        public TV()
        {
            CurrentChannel = 1;
        }
        public TV(string m, string r, int f, int c) : base(m, r, f)
        {
            Channels = c;
            CurrentChannel = 1;
        }

        public void ShowTVProgramm()
        {
            Console.WriteLine($"I am showing a TV programm on {CurrentChannel} channel!");
        }
        public void NextChannel()
        {
            if (CurrentChannel < Channels)
                ++CurrentChannel;
        }
        public void PrevChannel()
        {
            if (CurrentChannel > 1)
                --CurrentChannel;
        }

        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Channels: {Channels}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Device device = new Device();

            Monitor monitor = new Monitor("LG", "1920x1080", 60);

            monitor.SwitchPower();
            monitor.PrintInfo();
            monitor.DisplayPicture();

            TV tv = new TV("Samsumg", "2330x1750", 75, 32);

            tv.SwitchPower();
            tv.PrintInfo();
            tv.NextChannel();
            tv.ShowTVProgramm();
        }
    }
}

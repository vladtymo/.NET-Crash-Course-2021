using System;
using System.IO;

namespace _06_polymorphism
{
    abstract class Device
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

        // abstract - without realizaiton
        public abstract void DoWork();

        // polymorphism - with the keywords {virtual} and {override}
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Device: {Model} : {SerialNumber}\n" +
                $"Manufacture Date: {ManufactureDate.ToShortDateString()}\n" +
                $"Status: {Status}");
        }
        public virtual void ShowName()
        {
            Console.WriteLine("----- Device -----");
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
                Console.WriteLine($"I am displaying a picture with {Resolution} resolution!");
            else
                Console.WriteLine("Please turn the monitor on to display!");
        }
        // new - exclicit hide the inherited member
        // override - change base class methods realization
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Resolution: {Resolution}\n" +
                $"Frequency: {Frequency}Hz");
        }
        
        public override void ShowName()
        {
            Console.WriteLine("----- Monitor -----");
        }

        // sealed override - can not be overriden by derived classes
        public /*sealed*/ override void DoWork()
        {
            DisplayPicture();
        }
    }

    // sealed - can not has any child
    sealed class TV : Monitor
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

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Channels: {Channels}");
        }
        public override void ShowName()
        {
            Console.WriteLine("----- TV -----");
        }
        public override void DoWork()
        {
            ShowTVProgramm();
        }
    }

    // class SmartTV : TV { } // error with inheritance sealed class
    class Program
    {
        static void TestDevice(Device device)
        {
            device.ShowName();
            device.DoWork();
        }
        static void Main(string[] args)
        { 
            // Device device = new Device(); // cannon create an instance of an abstract class
            Monitor monitor = new Monitor("LG", "1920x1080", 60);
            TV tv = new TV("Samsumg", "2330x1750", 75, 32);

            tv.PrintInfo();
            tv.ShowName();

            Device device = new Monitor();
            device = monitor;
            device = tv;

            TestDevice(device);
            TestDevice(monitor);
            TestDevice(tv);

            ////// array of devices
            Device[] devices = new Device[]
            {
                device,
                monitor,
                tv,
                new Monitor("Sony", "1550x720", 120)
            };

            foreach (var d in devices)
            {
                d.SwitchPower();
                d.DoWork();
            }

            ///////////////// Type Casting
            TV television = null;

            // 1 - using conversion type operator
            try
            {
                television = (TV)devices[2];
                television.ShowTVProgramm();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Incorrect type!");
            }

            // 2 - using operator 'as'
            television = devices[2] as TV;

            if (television != null)
                television.ShowTVProgramm();
            else
                Console.WriteLine("Incorrect type!");

            // 3 - using 'is' and 'as' operators
            if (devices[2] is TV)
            {
                television = devices[2] as TV;
                television.ShowTVProgramm();
            }
            else
                Console.WriteLine("Incorrect type!");
        }
    }
}

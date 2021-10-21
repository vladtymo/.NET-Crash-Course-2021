using System;
using System.Collections;
using System.Collections.Generic;

namespace _08_system_interfaces
{
    // Common Interfaces: IEnumerable, ICloneable, IComparable, IComparer

    class Stat : ICloneable
    {
        public int Games { get; set; }
        public int Goals { get; set; }
        public float AvgGloals => (float)Goals / Games;

        public Stat() { }
        public Stat(int games, int goals)
        {
            Goals = goals;
            Games = games;
        }
        public override string ToString()
        {
            return $"Games: {Games}\n" +
                   $"Goals: {Goals}\n" +
                   $"Average Goals per Game: {AvgGloals}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    class Player : IComparable<Player>, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public Stat Statistics { get; set; }

        public object Clone()
        {
            // shallow copy - copy all value types
            Player copy = (Player)this.MemberwiseClone();
            // deep copy - copy all reference types
            copy.FirstName = (string)this.FirstName.Clone();
            copy.LastName = (string)this.LastName.Clone();
            copy.Statistics = (Stat)this.Statistics.Clone();

            return copy;
        }

        public int CompareTo(Player other)
        {
            return this.Statistics.AvgGloals.CompareTo(other.Statistics.AvgGloals);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}\t{Statistics.AvgGloals}\t{Birthdate.ToShortDateString()}";
        }
    }
    class Team : IEnumerable
    {
        private Player[] players;

        public Team()
        {
            players = new Player[4]
            {
                new Player()
                {
                    FirstName = "Andrii",
                    LastName = "Shevchenko",
                    Birthdate = new DateTime(1977, 9, 29),
                    Statistics = new Stat(150, 45)
                },
                new Player()
                {
                    FirstName = "Serhii",
                    LastName = "Rebrov",
                    Birthdate = new DateTime(1985, 3, 2),
                    Statistics = new Stat(101, 40)
                },
                new Player()
                {
                    FirstName = "Anatolii",
                    LastName = "Tymoshchuk",
                    Birthdate = new DateTime(1979, 10, 8),
                    Statistics = new Stat(144, 37)
                },
                new Player()
                {
                    FirstName = "Artem",
                    LastName = "Fetetskii",
                    Birthdate = new DateTime(1988, 12, 1),
                    Statistics = new Stat(133, 55)
                }
            };
        }

        public IEnumerator GetEnumerator()
        {
            return players.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(players);
        }
        public void Sort(IComparer<Player> comparer)
        {
            Array.Sort(players, comparer);
        }
    }

    class NameComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
    class BirthdateComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.Birthdate.CompareTo(y.Birthdate);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player()
            {
                FirstName = "Bob",
                LastName = "Bobovich",
                Birthdate = new DateTime(1990, 1, 1),
                Statistics = new Stat(10, 20)
            };

            Player secondPlayer = (Player)player.Clone(); // deep copy
            secondPlayer.Birthdate = DateTime.Now;
            secondPlayer.Statistics.Goals = 0;

            Console.WriteLine(player);

            //Team team = new Team();

            //foreach (Player p in team)
            //{
            //    Console.WriteLine(p);
            //}

            //Console.WriteLine("\n--------- After sorting --------");
            //team.Sort();
            //foreach (Player p in team)
            //{
            //    Console.WriteLine(p);
            //}

            //Console.WriteLine("\n--------- After name sorting --------");
            //team.Sort(new NameComparer());
            //foreach (Player p in team)
            //{
            //    Console.WriteLine(p);
            //}

            //Console.WriteLine("\n--------- After birthdate sorting --------");
            //team.Sort(new BirthdateComparer());
            //foreach (Player p in team)
            //{
            //    Console.WriteLine(p);
            //}
        }
    }
}

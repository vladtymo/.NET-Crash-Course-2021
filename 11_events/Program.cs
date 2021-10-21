using System;

namespace _11_events
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public void PassExam(string task)
        {
            Console.WriteLine($"Student {FirstName} {LastName} passed the exam task {task}");
        }
    }

    //public delegate void ExamDelegate(string task);
    class Teacher
    {
        public event Action<string> ExamEvent;
        public void CreateExam(string task)
        {
            Console.WriteLine($"Exam task '{task}' was created!");
            // start event
            ExamEvent?.Invoke(task);
        }
    }

    public class Helper
    {
        public event Action SomeEvent1;
        public event Action<string> EventWithParams2;
        public event Action<int, bool, string> EventWithParams3;

        public event Func<int, string> EventWithReturn1;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] group = new Student[]
            {
               new Student()
               {
                   FirstName = "Vova",
                   LastName = "Vaergre",
                   Birthdate = new DateTime(2005, 10, 10),
               },
               new Student()
               {
                   FirstName = "Olga",
                   LastName = "Frnbjer",
                   Birthdate = new DateTime(2002, 8, 1),
               },
               new Student()
               {
                   FirstName = "Igor",
                   LastName = "Forkdn",
                   Birthdate = new DateTime(1998, 9, 12),
               },
               new Student()
               {
                   FirstName = "Sasha",
                   LastName = "Nfojkdirt",
                   Birthdate = new DateTime(2004, 3, 10),
               }
            };

            Teacher teacher = new Teacher();

            foreach (var st in group)
            {
                // subscribe
                teacher.ExamEvent += st.PassExam;
            }
            // unsubscribe
            teacher.ExamEvent -= group[0].PassExam;
            //teacher.ExamEvent = null;

            teacher.CreateExam("The Fundamentals of C# Language");
        }
    }
}

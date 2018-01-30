using System;
using System.Collections.Generic;
using System.Linq;

namespace student
{
    class Student
    {
        public string Name { get; private set; }
        public Dictionary<string, int> Marks { get; private set; }
        public Student(string name, Dictionary<string, int> marks)
        {
            this.Name = name;
            this.Marks = marks;
        }

        public double getAverageScore()
        {
           return this.Marks.Values.Average(num => Convert.ToInt64(num));
        }

        public override string ToString()
        {
            string allMarks = Marks.ToList().Aggregate("", (acc, pair) => acc += $"{pair.Key}: {pair.Value}; ");
            return $"{Name}; average: {getAverageScore()}. {allMarks}";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var student1 = new Student("Alex", new Dictionary<string, int>()
                {
                    {"dotnet", 91},
                    {"haskell", 99},
                    {"prolog", 90},
                    {"math", 61}
                }
            );
            var student2 = new Student("Mih", new Dictionary<string, int>()
                {
                    {"dotnet", 61},
                    {"haskell", 77},
                    {"prolog", 84},
                    {"math", 90}
                }
            );
            var student3 = new Student("Jane", new Dictionary<string, int>()
                {
                    {"dotnet", 67},
                    {"haskell", 61},
                    {"prolog", 71},
                    {"math", 65}
                }
            );
            var student4 = new Student("July", new Dictionary<string, int>()
                {
                    {"dotnet", 100},
                    {"haskell", 100},
                    {"prolog", 95},
                    {"math", 99}
                }
            );
            List<Student> students = new List<Student>{ student1, student2, student3, student4 };
            students.Sort((a, b) => b.getAverageScore().CompareTo(a.getAverageScore()));
            students.ForEach(Console.WriteLine);
        }
    }
}

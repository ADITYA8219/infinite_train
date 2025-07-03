using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc2._1
{
    public abstract class Student
    {
        public string StudName { get; private set; }
        public string StudId { get; private set; }
        public double StudGrade { get; protected set; }

        public Student(string name, string id)
        {

            StudName = name;
            StudId = id;
            StudGrade = 0.0;
        }

        public void SetGrade(double grade)
        {
            StudGrade = grade;
        }

        public abstract bool IsPassed(double grade);

        public virtual void DisplayStudInfo()
        {
            Console.WriteLine($"\nDetails of students");
            Console.WriteLine($"Name: {StudName}");
            Console.WriteLine($"USN: {StudId}");
            Console.WriteLine($"Grade: {StudGrade:F2}");
        }
    }

    public class Undergraduate : Student
    {
        public Undergraduate(string name, string id) : base(name, id)
        {
        }

        public override bool IsPassed(double grade)
        {
            return grade >= 70.0;
        }

        public override void DisplayStudInfo()
        {
            base.DisplayStudInfo();
            Console.WriteLine($"Student Type: Undergraduate");
            Console.WriteLine($"Passing Score: >=70.0");
            Console.WriteLine($"Passed Course: {IsPassed(StudGrade)}");
           
        }
    }

    public class Graduate : Student
    {
        public Graduate(string name, string id) : base(name, id)
        {
        }

        public override bool IsPassed(double grade)
        {
            return grade >= 80.0;
        }

        public override void DisplayStudInfo()
        {
            base.DisplayStudInfo();
            Console.WriteLine($"Student Type: Graduate");
            Console.WriteLine($"Passing Score: >=80");
            Console.WriteLine($"Passed Course: {IsPassed(StudGrade)}");
           
        }
    }

    public class AcademicSystem
    {
        public static void Main(string[] args)
        {
           

            Console.WriteLine("Undergraduate student:");
            Undergraduate u1 = new Undergraduate("Virat", "UG18");
            u1.SetGrade(91.5);
            u1.DisplayStudInfo();

            Undergraduate u2 = new Undergraduate("Rohit", "UG45");
            u2.SetGrade(34.0);
            u2.DisplayStudInfo();


            Console.WriteLine("Graduate student:");
            Graduate g1 = new Graduate("Gill", "GR01");
            g1.SetGrade(81.0);
            g1.DisplayStudInfo();

            Graduate g2 = new Graduate("Rishabh", "GR17");
            g2.SetGrade(98.8);
            g2.DisplayStudInfo();

          
            Console.Read();
        }
    }
}

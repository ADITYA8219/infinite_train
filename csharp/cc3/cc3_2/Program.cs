using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc3_2
{
    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box AddBoxes(Box fBox, Box sBox)
        {
            Box tBox = new Box();
            tBox.Length = fBox.Length + sBox.Length;
            tBox.Breadth = fBox.Breadth + sBox.Breadth;
            return tBox;
        }

        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    public class Test
    {
        public static void Main(string[] args)
        {
            Box Box1 = new Box();
            Console.Write("Enter Length of box1: ");
            Box1.Length = double.Parse(Console.ReadLine());
            Console.Write("Enter Breadth of box1: ");
            Box1.Breadth = double.Parse(Console.ReadLine());

            Box Box2 = new Box();
            Console.Write("Enter Length of box2: ");
            Box2.Length = double.Parse(Console.ReadLine());
            Console.Write("Enter Breadth of box2: ");
            Box2.Breadth = double.Parse(Console.ReadLine());

            Box cal = new Box();
            Box Box3 = cal.AddBoxes(Box1, Box2);

            Console.WriteLine("\nDetails of the Third Box");
            Box3.Display();
            Console.ReadKey();
        }
    }
}

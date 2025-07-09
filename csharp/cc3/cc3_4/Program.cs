using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc3_4
{ 

    public class Calculator
    {
        public delegate int OperationDelegate(int fOperand, int sOperand);

        public static int Add(int fOperand, int sOperand)
        {
            return fOperand + sOperand;
        }

        public static int Subtract(int fOperand, int sOperand)
        {
            return fOperand - sOperand;
        }

        public static int Multiply(int fOperand, int sOperand)
        {
            return fOperand * sOperand;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter the first integer: ");
            int fnum = int.Parse(Console.ReadLine());

            Console.Write("Enter the second integer: ");
            int snum = int.Parse(Console.ReadLine());

            OperationDelegate addOperation = Add;
            OperationDelegate subOperation = Subtract;
            OperationDelegate multiplyOperation = Multiply;

            Console.WriteLine("\nResults");
            Console.WriteLine($"Addition: {fnum} + {snum} = {addOperation(fnum, snum)}");
            Console.WriteLine($"Subtraction: {fnum} - {snum} = {subOperation(fnum, snum)}");
            Console.WriteLine($"Multiplication: {fnum} * {snum} = {multiplyOperation(fnum, snum)}");

            Console.ReadKey();
        }
    }
}

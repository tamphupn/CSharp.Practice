using System;
using System.Collections.Generic;
using System.Linq;

namespace FreelancerRefactor
{
    public enum CalculatorType
    {
        Add = 1,
        Subtract = 2,
        Multiply = 3
    }

    public interface ICalculatorService
    {
        int Compute();
        bool IsAvailable(int choice);
    }

    public abstract class Calculator: ICalculatorService
    {
        protected int Num1;
        protected int Num2;

        public Calculator(int num1, int num2)
        {
            Num1 = num1;
            Num2 = num2;
        }

        public abstract int Compute();
        public abstract bool IsAvailable(int choice);
    }

    public class AddCalculator : Calculator
    {
        private const CalculatorType CALC_TYPE = CalculatorType.Add;

        public AddCalculator(int num1, int num2) : base(num1, num2)
        {
        }

        public override int Compute()
        {
            return Num1 + Num2;
        }

        public override bool IsAvailable(int choice)
        {
            return choice == (int)CALC_TYPE;
        }
    }

    public class SubtractCalculator : Calculator
    {
        private const CalculatorType CALC_TYPE = CalculatorType.Subtract;

        public SubtractCalculator(int num1, int num2) : base(num1, num2)
        {
        }

        public override int Compute()
        {
            return Num1 - Num2;
        }

        public override bool IsAvailable(int choice)
        {
            return choice == (int)CALC_TYPE;
        }
    }

    public class MultiplyCalculator : Calculator
    {
        private const CalculatorType CALC_TYPE = CalculatorType.Multiply;

        public MultiplyCalculator(int num1, int num2) : base(num1, num2)
        {
        }

        public override int Compute()
        {
            return Num1 * Num2;
        }

        public override bool IsAvailable(int choice)
        {
            return choice == (int)CALC_TYPE;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers:");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            List<Calculator> calculatorTypes = new List<Calculator>()
            {
                new AddCalculator(num1, num2),
                new SubtractCalculator(num1, num2),
                new MultiplyCalculator(num1, num2),
            };

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            int choice = int.Parse(Console.ReadLine());

            var userChoiced = calculatorTypes.FirstOrDefault(x => x.IsAvailable(choice));
            if (userChoiced == null)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }
            int result = userChoiced.Compute();
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
    }
}


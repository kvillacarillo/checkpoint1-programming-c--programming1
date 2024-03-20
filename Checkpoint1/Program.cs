//initialize starting class
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint1
{
    class Program
    {
        private delegate void fMathOperation(double num1, double num2);
        static void Main(string[] args)
        {
            bool gracefullyCompleted = false;
            var operations = new Dictionary<string, fMathOperation>
            {
                {"+", Add},
                {"-", Subtract},
                {"*", Multiply},
                {"/", Divide},
                {"E", Exit}
            };


            Console.WriteLine("Checkpoint 1 Simple Calculator");
            InputHandler<double>("First number", out double num1);
            InputHandler<double>("Second number", out double num2);
          

            do
            {
                DisplayMenu();
                InputHandler<string>("Enter operation", out string operation);
                if (operations.ContainsKey(operation))
                {
                    operations[operation](num1, num2);

                    gracefullyCompleted = true;
                }
            }
            while (!gracefullyCompleted);

        }


        private static T InputHandler<T>(String inputName, out T value) where T : IConvertible
        {
            string input;
            try
            {
                Console.WriteLine("Enter the " + inputName + typeof(T).Name);
                input = Console.ReadLine() ?? "";

                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception();
                }

                value = (T)Convert.ChangeType(input, typeof(T));

                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InputHandler(inputName, out value);
            }
        }


        private static void DisplayMenu()
        {
            Console.WriteLine("+. Add");
            Console.WriteLine("-. Subtract");
            Console.WriteLine("*. Multiply");
            Console.WriteLine("/. Divide");
            Console.WriteLine("E. Exit");
        }

        private static void Exit(double num1, double num2)
        {
            Console.WriteLine("Goodbye!");
        }

        private static void Add(double num1, double num2)
        {
            Console.WriteLine("The sum of " + num1 + " and " + num2 + " is " + (num1 + num2));
        }

        private static void Subtract(double num1, double num2)
        {
            Console.WriteLine("The difference of " + num1 + " and " + num2 + " is " + (num1 - num2));
        }

        private static void Multiply(double num1, double num2)
        {
            Console.WriteLine("The product of " + num1 + " and " + num2 + " is " + (num1 * num2));
        }

        private static void Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            else
            {
                Console.WriteLine("The quotient of " + num1 + " and " + num2 + " is " + (num1 / num2));
            }
        }
    }
}
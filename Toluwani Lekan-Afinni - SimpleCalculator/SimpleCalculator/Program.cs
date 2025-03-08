namespace SimpleCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Simple Calculator");

            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter operator (+, -, *, /): ");
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            SimpleCalculator(num1, num2, op);

        }

        /// <summary>
        /// SimpleCalculator: Models a simple calculator, and displays result of operation
        /// on the console
        /// </summary>
        /// <param name="FirstValue"></param>
        /// <param name="SecondValue"></param>
        /// <param name="Operation"></param>
        static void SimpleCalculator(double FirstValue, double SecondValue, char Operation)
        {
            double result = 0;

            if (Operation == '+')
            {
                result = FirstValue + SecondValue;
            }
            else if (Operation == '-')
            {
                result = FirstValue - SecondValue;
            }
            else if (Operation == '*')
            {
                result = FirstValue * SecondValue;
            }
            else if (Operation == '/')
            {
                result = FirstValue / SecondValue;
            }
            else
            {
                Console.WriteLine($"{Operation} is invalid");
            }

             Console.WriteLine($"Result: {FirstValue} {Operation} {SecondValue} = {result}");
            }
        }

    }


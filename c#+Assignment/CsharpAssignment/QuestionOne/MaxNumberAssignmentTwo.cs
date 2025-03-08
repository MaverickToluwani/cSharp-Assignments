namespace QuestionOne.CsharpAssignment
{
  public static class MaxNumberAssignmentTwo
  {
        /// <summary>
        /// MaxNumber: Determines the max number between two numbers
        /// <returns>Returns void, but Displays results to the console</returns>
        /// </summary>
        public static void MaxNumber()
        {
            Console.Write("Enter first number: ");

            var value1 = Console.ReadLine();

            Console.Write("Enter Second number: ");

            var value2 = Console.ReadLine();

            bool isNumber1 = int.TryParse(value1, out int ConvertedVal1);

            bool isNumber2 = int.TryParse(value2, out int ConvertedVal2);

            if (isNumber1 && isNumber2)
            {
                if(ConvertedVal1 > ConvertedVal2)
                Console.WriteLine($"{ConvertedVal1} is the max value");
                else
                Console.WriteLine($"{ConvertedVal2} is the max value");
            }
            else
            {
                Console.WriteLine("value1 or value2 is not a valid number");
            }
        }
  }
}
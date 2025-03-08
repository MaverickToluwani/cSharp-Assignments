//FactoialAssignment3

namespace QuestionTwo.CsharpAssignment
{
  public static class FactoialAssignmentThree
  {
        /// <summary>
        /// FactoialShell: Compute the factorial of any number entered by the user using recursion 
        /// <returns>Returns void, but Displays results to the console</returns>
        /// </summary>
      public static void FactoialShell()
      {

        Console.Write("Enter number: ");

        string number = Console.ReadLine();

        bool isNumber = int.TryParse(number, out int ConvertedNum);

        if (isNumber)
        {
            int res = Factoial(ConvertedNum);
            Console.WriteLine($"{number}!: {res}");
        }
        else
        {
          Console.Write("You have an invalid entered number");
        }

      }

        /// <summary>
        /// Factoial: Compute the factorial of any number using recursion 
        /// <param name="number">number to be factorized.</param>
        /// <returns>Returns result of factorization process</returns>
        /// </summary>
      public static int Factoial(int number)
      {
        if (number == 0 || number == 1)
          return 1;

        return number * Factoial(number - 1);
      }
  }
}
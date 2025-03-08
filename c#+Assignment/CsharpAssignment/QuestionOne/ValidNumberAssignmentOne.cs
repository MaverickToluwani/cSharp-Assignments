namespace CsharpAssignment.QuestionOne
{
  public static class ValidNumberAssignmentOne
  {
        /// <summary>
        /// ValidNumber: Checks if a number entered by the user is between 1 and 10
        /// <returns>Returns void, but Displays results to the console</returns>
        /// </summary>
      public static void ValidNumber()
      {
        Console.Write("Enter a number: ");

        var value = Console.ReadLine();

        bool isNumber = int.TryParse(value, out int ConvertedVal);

        if (isNumber)
        {
          if(ConvertedVal > 0 && ConvertedVal <= 10 )
            Console.WriteLine("Valid");
          else
            Console.WriteLine("Not Valid");
        }
        else
        {
          Console.WriteLine("Not a valid number");
        }
      }
  }
}
//EnterNumberAssignment2
namespace QuestionTwo.CsharpAssignment
{
  public static class EnterNumberAssignmentTwo
  {
        /// <summary>
        /// EnterNumber: Checks if a what is entered by the user is a number then sums them up
        ///              until user enters ok.
        /// <returns>Returns void, but Displays results to the console</returns>
        /// </summary>
      public static void EnterNumber()
      {

        bool flag = true;

        int sum = 0;

        while(flag)
        {
              Console.Write("Enter number or enter ok to end program: ");

              string number = Console.ReadLine();

              bool isNumber = int.TryParse(number, out int ConvertedNum);

              if (isNumber)
              {
                  sum += ConvertedNum;
                  Console.WriteLine($"sum: {sum}");
              }
              else
              {
                if(number.Equals("ok"))
                  flag = false;
              }
        }
      }
  }
}
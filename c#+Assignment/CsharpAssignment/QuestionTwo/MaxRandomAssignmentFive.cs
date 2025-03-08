
namespace QuestionTwo.CsharpAssignment
{
  public static class MaxRandomAssignmentFive
  {

        /// <summary>
        /// MaxRandom: Looks for the max number of random number entered by the user  
        /// <returns>Returns null, but displays max number to console</returns>
        /// </summary>
      public static void MaxRandom()
      {
          Console.Write("Enter a list of numbers: ");

          string Numbers = Console.ReadLine();

          string[] holder = Numbers.Split(',');

          int[] intConvertedString = new int[holder.Length];

          for (int i = 0; i < holder.Length; i++)
          {
            bool isNumber = int.TryParse(holder[i], out int ConvertedNum);

            if(isNumber)
            {
              intConvertedString[i] = ConvertedNum;
            }
          }

          Console.WriteLine("The max number is: " + intConvertedString.Max());
      }
  }
}
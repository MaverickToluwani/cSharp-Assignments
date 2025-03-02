
namespace Question2.CsharpAssignment
{
  public static class MaxRandomAssignment5
  {
      public static void MaxRandom()
      {
          Console.Write("Enter a list of numbers: ");

          string Numbers = Console.ReadLine();

          string[] holder = Numbers.Split(',');

          int[] intConvertedString = new int[holder.Length];

          for (int i = 0; i < holder.Length; i++)
          {
            bool isNumber = int.TryParse(holder[i], out int ConvertedNum);
            //by defualt non numbers will be 0
            //doesnt matter since we are looking for max
            if(isNumber)
            {
              intConvertedString[i] = ConvertedNum;
            }
          }

          Console.WriteLine("The max number is: " + intConvertedString.Max());
      }
  }
}
//EnterNumberAssignment2
namespace Question2.CsharpAssignment
{
  public static class EnterNumberAssignment2
  {
      public static void EnterNumber()
      {

        bool flag = true;

        int sum = 0;

        while(flag)
        {
              Console.Write("Enter number: ");

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
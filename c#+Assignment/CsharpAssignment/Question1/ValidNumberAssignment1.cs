namespace CsharpAssignment
{
  public static class ValidNumberAssignment1
  {
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
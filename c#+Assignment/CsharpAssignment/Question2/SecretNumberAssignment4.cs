//SecretNumberAssignment4

namespace Question2.CsharpAssignment
{
  public static class SecretNumberAssignment4
  {
      public static void SecretNumber()
      {
          //Random number generation
          Random rnd = new Random();
          int num = rnd.Next(1, 10);
          Console.WriteLine ($"The Secret number is {num}");

          Console.Write("Enter the Secret number: ");

          string GuessedSecretNum = Console.ReadLine();

          bool isNumber = int.TryParse(GuessedSecretNum, out int ConvertedNum);

          if (isNumber)
          {
            if( ConvertedNum == num)
              Console.WriteLine ("You won");
            else
              Console.WriteLine ("You lost");
          }
          else
          {
            Console.WriteLine(" You have entered an invalid number");
          }
      }
  }
}
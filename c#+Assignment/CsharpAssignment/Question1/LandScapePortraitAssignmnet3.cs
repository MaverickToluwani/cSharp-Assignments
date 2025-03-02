//LandScapePortraitAssignmnet3

namespace Question1.CsharpAssignment
{
  public static class LandScapePortraitAssignmnet3
  {
      public static void LandScapePortrait()
      {
        Console.Write("Enter height Value: ");

        string height = Console.ReadLine();

        Console.Write("Enter Width Value: ");

        string Width = Console.ReadLine();

        bool isNumber1 = int.TryParse(height, out int Convertedheight);

        bool isNumber2 = int.TryParse(Width, out int ConvertedWidth);

        if (isNumber1 && isNumber2)
        {
          if(Convertedheight > ConvertedWidth)
            Console.WriteLine("Image is a potrait");
          else if(ConvertedWidth > Convertedheight)
            Console.WriteLine("Image is a Landscape");
          else
            Console.WriteLine("Image is a square");
        }
        else
        {
          Console.WriteLine("height or Width is not a valid number");
        }
      }
  }
}
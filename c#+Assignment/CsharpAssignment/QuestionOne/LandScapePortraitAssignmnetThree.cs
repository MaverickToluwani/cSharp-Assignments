//LandScapePortraitAssignmnet3

namespace QuestionOne.CsharpAssignment
{
  public static class LandScapePortraitAssignmnetThree
  {
        /// <summary>
        /// LandScapeProtrait: Determines if an image is a potrait, landscape or square
        ///                     by the dimensions entered
        /// <returns>Returns void but Displays results to the console</returns>
        /// </summary>
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
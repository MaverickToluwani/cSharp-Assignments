//LandScapePortraitAssignmnet3

namespace QuestionTwo.CsharpAssignment
{

  public static class Divideby3AssignmentOne
  {
        /// <summary>
        /// Divideby3: Checks if a number entered by the user is divisible by 3
        /// <returns>Returns void, but Displays results to the console</returns>
        /// </summary>
      public static void Divideby3()
      {

        for(int i = 0; i <= 100; i++)
        {
            if(i % 3 == 0)
            Console.WriteLine(i);
        }
      }
  }
}
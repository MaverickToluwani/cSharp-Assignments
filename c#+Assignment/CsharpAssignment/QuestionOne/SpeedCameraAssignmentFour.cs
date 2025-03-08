namespace QuestionOne.CsharpAssignment
{
    public static class SpeedCameraAssignmentFour
    {
        /// <summary>
        /// CheckSpeed: Determines if a car speed is above or below the speed limit
        /// <returns>Returns void, but Displays results to the console</returns>
        /// </summary>
        public static void CheckSpeed()
        {
            Console.Write("Enter the speed limit: ");
            string speedLimitInput = Console.ReadLine();

            Console.Write("Enter the car speed: ");
            string carSpeedInput = Console.ReadLine();

            bool isSpeedLimitValid = int.TryParse(speedLimitInput, out int speedLimit);
            bool isCarSpeedValid = int.TryParse(carSpeedInput, out int carSpeed);

            if (isSpeedLimitValid && isCarSpeedValid)
            {
                if (carSpeed <= speedLimit)
                {
                    Console.WriteLine("Ok");
                }
                else
                {
                    int excessSpeed = carSpeed - speedLimit;
                    int demeritPoints = excessSpeed / 5;

                    Console.WriteLine($"Demerit Points: {demeritPoints}");

                    if (demeritPoints > 12)
                    {
                        Console.WriteLine("License Suspended");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
        }
    }
}

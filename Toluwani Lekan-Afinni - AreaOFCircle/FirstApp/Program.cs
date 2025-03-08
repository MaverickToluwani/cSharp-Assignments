namespace AreaOfCircle
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            double r = 22;
            Double result = AreaOfCircle(r);
            Console.WriteLine(result);
        }

        /// <summary>
        /// AreaOfCircle: Calculates the area of a circle
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        static double AreaOfCircle(double radius)
        {
            const double PI = Math.PI;

            double AreaOFCircle = radius * PI;

            return AreaOFCircle;
        }
    }
}


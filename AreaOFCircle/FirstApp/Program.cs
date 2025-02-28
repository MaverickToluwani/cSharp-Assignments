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


        static double AreaOfCircle(double radius)
        {
            const double PI = Math.PI;

            double AreaOFCircle = radius * PI;

            return AreaOFCircle;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #14
    The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.

    Hint: The basic equation of a circle is x2 + y2 = r2.

    Notes:
    The Monte Carlo method relies on repeated random sampling to obtain numerical results. In this case we will rendomize x and y to calculate pi

    Draw a square, then inscribe a quadrant within it
    Uniformly scatter a given number of points over the square
    Count the number of points inside the quadrant, i.e. having a distance from the origin of less than 1
    The ratio of the inside-count and the total-sample-count is an estimate of the ratio of the two areas, π/4. 
    Multiply the result by 4 to estimate π.
*/
namespace DCP14
{
    public class DCP14
    {
        private static double MonteCarloApproximation()
        {
            double pi = 0;

            int inCircle = 0;
            double x, y;
            Random r = new Random();

            // do 1000000 iterations for decent accuracy, higher if needed
            for(int i = 1;i< 1000000; i++)
            {
                x = r.NextDouble();
                y = r.NextDouble();

                // check if values are inside the unit circle
                if(Math.Sqrt(x*x + y*y) <= 1.0)
                {
                    inCircle++;
                }

                pi = 4 * (double)inCircle / (double)i;
            }

            return pi;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(MonteCarloApproximation().ToString());
        }
    }
}

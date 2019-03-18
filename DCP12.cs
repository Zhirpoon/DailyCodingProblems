using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #12
    There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase. The order of the steps matters.

    For example, if N is 4, then there are 5 unique ways:

    1, 1, 1, 1
    2, 1, 1
    1, 2, 1
    1, 1, 2
    2, 2
    What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
*/
namespace DCP12
{
    public class DCP12
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Put in how many steps there are");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("Put in how many steps can be walked (array of alternatives)");
            var alternatives = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var waysToClimb = WaysToClimb(n, alternatives, 0);

            Console.WriteLine($"There are {waysToClimb} ways to climb.");
        }

        private static int WaysToClimb(int steps, List<int> alternatives, int climbedStairs)
        {
            if(climbedStairs > steps)
            {
                return 0;
            }
            else if(climbedStairs == steps)
            {
                return 1;
            }

            var waysToClimb = 0;

            foreach(var alternative in alternatives)
            {
                waysToClimb += WaysToClimb(steps, alternatives, climbedStairs + alternative);
            }

            return waysToClimb;
        }
    }
}

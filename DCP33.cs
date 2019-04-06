using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #33
    Compute the running median of a sequence of numbers. That is, given a stream of numbers, print out the median of the list so far on each new element.

    Recall that the median of an even-numbered list is the average of the two middle numbers.

    For example, given the sequence [2, 1, 5, 7, 2, 0, 5], your algorithm should print out:

    2
    1.5
    2
    3.5
    2
    2
    2
*/
namespace DCP33
{
    public class DCP33
    {
        public static void Main(string[] args)
        {
            var inputList = new int[] { 2, 1, 5, 7, 2, 0, 5 };

            var sortedList = new List<int>();

            foreach(var num in inputList)
            {
                sortedList.Add(num);
                sortedList.Sort();

                PrintMedian(sortedList);
            }
        }

        public static void PrintMedian(List<int> sortedList)
        {
            decimal result = 0M;

            if(sortedList == null || sortedList.Count == 0)
            {
                throw new Exception("Unacceptable list");
            }

            int half = sortedList.Count / 2;

            result = sortedList.Count % 2 == 0 
                ? (decimal)(sortedList[half] + sortedList[half - 1]) / 2 
                : (decimal)sortedList[half];

            Console.WriteLine(result.ToString("0.##"));
        }
    }
}

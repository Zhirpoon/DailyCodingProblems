using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #18
    Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.

    For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8], since:

    10 = max(10, 5, 2)
    7 = max(5, 2, 7)
    8 = max(2, 7, 8)
    8 = max(7, 8, 7)
    Do this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.
*/
namespace DCP18
{
    public class DCP18
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int.TryParse(Console.ReadLine(), out int k);

            for(int i = 0; i <= numbers.Count - k;i++)
            {
                Console.WriteLine(numbers.GetRange(i, k).Max());
            }
        }
    }
}

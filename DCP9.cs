using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #9
    Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. Numbers can be 0 or negative.

    For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.

    Follow-up: Can you do this in O(N) time and constant space?
*/
namespace DCP9
{
    public class DCP9
    {
        public static int GetNonAdjacentMaxSum(List<int> numbers, int firstPosition)
        {
            if (firstPosition > numbers.Count-1)
            {
                return 0;
            }
            if (firstPosition == numbers.Count-1)
            {
                return numbers[firstPosition];
            }
            else if (firstPosition == numbers.Count-2)
            {
                return numbers[firstPosition] > numbers[firstPosition + 1] ? numbers[firstPosition] : numbers[firstPosition + 1];
            }

            var firstNumber = numbers[firstPosition];

            // remove last number
            var withoutFirst = GetNonAdjacentMaxSum(numbers, firstPosition + 1);

            // remove adjacent number to last number
            var withFirst = GetNonAdjacentMaxSum(numbers, firstPosition + 2) + firstNumber;

            return withFirst > withoutFirst ? withFirst : withoutFirst;

        }

        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

            Console.WriteLine(GetNonAdjacentMaxSum(numbers, 0));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    #1
    Given a list of numbers and a number k, return whether any two numbers from the list add up to k.

    For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.

    Bonus: Can you do this in one pass? 
*/


namespace DCP1
{
    public class DCP1
    {
        public static void Main(string[] args)
        {     
            // retrieve the list of numbers
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            // retrive requested number to look for
            int.TryParse(Console.ReadLine(), out int requestedSum);

            var result = SumPair(numbers, requestedSum);

            Console.WriteLine(result);
        }

        public static string SumPair(List<int> numbers, int requestedSum)
        {
            // for the bonus point let's create a hashset to store numbers 
            var usableNumbers = new HashSet<int>();

            // loop list
            foreach (var number in numbers)
            {
                // calculate difference
                var diff = requestedSum - number;

                if (usableNumbers.Contains(diff))
                {
                    return $"The values {diff} + {number} = {requestedSum}.";
                }
                else
                {
                    usableNumbers.Add(number);
                }
            }

            return $"The requested sum {requestedSum} could not be achieved.";
        }
    }
}

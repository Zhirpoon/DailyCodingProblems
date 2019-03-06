using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
	#2
    Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.

    For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].

    Follow-up: what if you can't use division?
*/

namespace DCP2
{
    public class DCP2
    {
        public static void Main(string[] args)
        {
            // retrieve the list of numbers
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var withDivisionResults = WithDivisionProducts(numbers);
            var noDivisionResults = NoDivisionProducts(numbers);

            Console.WriteLine($"[{string.Join(",", withDivisionResults)}]");
            Console.WriteLine($"[{string.Join(",", noDivisionResults)}]");

        }

        public static List<int> WithDivisionProducts(List<int> numbers)
        {
            List<int> products = new List<int>();

            // get product
            var prod = numbers.Aggregate(1, (a,b) => a*b);

            // calculate products list
            foreach(var number in numbers)
            {
                products.Add(prod / number);
            }

            return products;
        }

        public static List<int> NoDivisionProducts(List<int> numbers)
        {
            List<int> products = new List<int>();

            for(int i = 0; i < numbers.Count; i++)
            {
                var prod = 1;

                for(int j = 0; j < numbers.Count; j++)
                {
                    if(j != i)
                    {
                        prod *= numbers[j];
                    }
                }

                products.Add(prod);
            }

            return products;
        }
    }
}

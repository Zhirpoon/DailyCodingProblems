using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #13
    Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.

    For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
*/
namespace DCP13
{
    public class DCP13
    {


        public static void Main(string[] args)
        {
            Console.WriteLine("Write the maximum number of distinct characters");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("Write the text to be analyzed");
            var text = Console.ReadLine();

            var longestSubString = LongestSubString(n, text);

            Console.WriteLine($"The longest substring is: \"{longestSubString}\"");

        }

        public static string LongestSubString(int max, string text)
        {
            var uniques = new List<char>();

            if(text.Length <= max)
            {
                return text;
            }
            
            foreach(var c in text)
            {
                if (!uniques.Contains(c))
                {
                    uniques.Add(c);
                }
            }

            if(uniques.Count > max)
            {
                var first = LongestSubString(max, text.Substring(1));
                var last = LongestSubString(max, text.Substring(0, text.Length - 1));

                // return either when they're as long
                if(first.Length > last.Length)
                {
                    return first;
                }
                else
                {
                    return last;
                }
            }
            else
            {
                return text;
            }
        }
    }
}

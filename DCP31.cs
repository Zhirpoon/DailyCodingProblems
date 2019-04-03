using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #31
    The edit distance between two strings refers to the minimum number of character insertions, deletions, and substitutions required to change one string to the other. 
    For example, the edit distance between “kitten” and “sitting” is three: substitute the “k” for “s”, substitute the “e” for “i”, and append a “g”.
*/
namespace DCP31
{
    public class DCP31
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter first word");
            var word1 = Console.ReadLine();

            Console.WriteLine("Enter second word");
            var word2 = Console.ReadLine();

            Console.WriteLine($"The edit distance between {word1} and {word2} is {GetEditDistance(word1, word2)}");
        }

        public static int GetEditDistance(string word1, string word2)
        {
            var editDistance = 0;

            // calulate difference in length
            var diff = Math.Abs(word1.Length - word2.Length);

            editDistance += diff;

            if(word1.Length > word2.Length)
            {
                word1 = word1.Substring(0, word1.Length - diff);
            }
            else if (word1.Length < word2.Length)
            {
                word2 = word2.Substring(0, word2.Length - diff);
            }

            for(int i = 0; i < word1.Length; i++)
            {
                if(word1[i] != word2[i])
                {
                    editDistance++;
                }
            }

            return editDistance;
        }
    }
}

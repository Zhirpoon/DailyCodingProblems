using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #34
    Given a string, find the palindrome that can be made by inserting the fewest number of characters as possible anywhere in the word. 
    If there is more than one palindrome of minimum length that can be made, return the lexicographically earliest one (the first one alphabetically).

    For example, given the string "race", you should return "ecarace", since we can add three letters to it (which is the smallest amount to make a palindrome). 
    There are seven other palindromes that can be made from "race" by adding three letters, but "ecarace" comes first alphabetically.

    As another example, given the string "google", you should return "elgoogle".
*/
namespace DCP34
{
    public class DCP34
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a word to find its palindrome.");
            var word = Console.ReadLine();

            Console.WriteLine($"The smallest, and the lexicographically earliest palindrome for the word {word} is : {GetSmallestPalindrome(word)}");
        }

        public static string GetSmallestPalindrome(string word)
        {
            // cover null and empty string cases
            if (string.IsNullOrWhiteSpace(word))
            {
                return "No word provided.";
            }

            var results = GetAllPalindromes(word);

            // order the results
            results
                .OrderBy(m => m.Length)
                .ThenBy(m => m);

            return results.First();
        }

        public static List<string> GetAllPalindromes(string word)
        {
            var palindromes = new List<string>();

            if (IsPalindrome(word))
            {
                palindromes.Add(word);
            }
            else
            {
                // only loop halfway as we go from both the left and right
                for(int i = 0; i < word.Length / 2; i++)
                {
                    // skip letter if it is the same
                    if(word[i] != word[word.Length - (i + 1)])
                    {
                        // add to left side
                        var newWord1 = word.Insert(i, "" + word[word.Length - (i + 1)]);

                        // add to right side
                        var newWord2 = word.Insert(word.Length - i, "" + word[i]);

                        // recursive from left
                        palindromes.AddRange(GetAllPalindromes(newWord1));

                        // recursive from right
                        palindromes.AddRange(GetAllPalindromes(newWord2));

                        return palindromes;
                    }
                }
            }

            return palindromes;
        }

        public static bool IsPalindrome(string word)
        {
            return new string(word.Reverse().ToArray()) == word;
        }
    }
}

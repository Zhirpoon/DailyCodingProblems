using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #22
    Given a dictionary of words and a string made up of those words (no spaces), return the original sentence in a list. If there is more than one possible reconstruction, return any of them. If there is no possible reconstruction, then return null.

    For example, given the set of words 'quick', 'brown', 'the', 'fox', and the string "thequickbrownfox", you should return ['the', 'quick', 'brown', 'fox'].

    Given the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', and the string "bedbathandbeyond", return either ['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].
*/
namespace DCP22
{
    public class DCP22
    {
        public static void Main(string[] args)
        {
            var words1 = new List<string> { "quick", "brown", "the", "fox" };
            var text1 = "thequickbrownfox";

            var words2 = new List<string> { "bed", "bath", "bedbath", "and", "beyond" };
            var text2 = "bedbathandbeyond";

            var result1 = GetTextArray(text1, words1);
            var result2 = GetTextArray(text2, words2);

            if(result1 != null)
            {
                Console.WriteLine($"[{string.Join(", ", result1)}]");
            }

            if (result2 != null)
            {
                Console.WriteLine($"[{string.Join(", ", result2)}]");
            }

        }

        public static ICollection<string> GetTextArray(string text, List<string> words)
        {
            var results = new List<string>();

            var word = "";

            foreach (var c in text)
            {
                word += c;
                if (words.Contains(word))
                {
                    results.Add(word);
                    word = "";
                }
            }

            return string.Join("", results) == text ? results : null;
        }
    }
}

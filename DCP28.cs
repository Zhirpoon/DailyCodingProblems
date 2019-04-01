using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #28
    Write an algorithm to justify text. Given a sequence of words and an integer line length k, return a list of strings which represents each line, fully justified.

    More specifically, you should have as many words as possible in each line. 
    There should be at least one space between each word. 
    Pad extra spaces when necessary so that each line has exactly length k. 
    Spaces should be distributed as equally as possible, with the extra spaces, if any, distributed starting from the left.

    If you can only fit one word on a line, then you should pad the right-hand side with spaces.

    Each word is guaranteed not to be longer than k.

    For example, given the list of words ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"] and k = 16, you should return the following:

    ["the  quick brown", # 1 extra space on the left
    "fox  jumps  over", # 2 extra spaces distributed evenly
    "the   lazy   dog"] # 4 extra spaces distributed evenly
*/
namespace DCP28
{
    public class DCP28
    {
        public static void Main(string[] args)
        {
            var words = new List<string>() { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            var rowLength = 16;

            var result = BuildPaddedRows(words, rowLength);

            foreach(var r in result)
            {
                Console.WriteLine($"\"{r}\"");
            }
        }

        public static List<string> BuildPaddedRows(List<string> words, int rowLength)
        {
            var currentRow = new List<string>();

            if(words.Count == 0)
            {
                var res = new StringBuilder();
                res.Append(' ', rowLength);
                return new List<string> { res.ToString() };
            }

            var result = new List<string>();


            foreach(var word in words)
            {
                if((currentRow.Sum(w => w.Length) + currentRow.Count + word.Length < rowLength) || currentRow.Count == 0)
                {
                    currentRow.Add(word);
                }
                else
                {
                    result.Add(PadRow(currentRow, rowLength));
                    currentRow.Clear();
                    currentRow.Add(word);
                }
            }

            if(currentRow.Count != 0)
            {
                result.Add(PadRow(currentRow, rowLength));
                currentRow.Clear();
            }

            return result;
        }

        public static string PadRow(List<string> words, int rowLength)
        {
            var paddedRow = new StringBuilder();

            if(words.Count == 1)
            {
                if(words[0].Length == rowLength)
                {
                    return words[0];
                }
                else
                {
                    paddedRow.Append(words[0]);
                    paddedRow.Append(' ', rowLength - words[0].Length);
                    return paddedRow.ToString();
                }
            }

            //if(string.Join(" ", words).Length == rowLength)
            //{
            //    return string.Join(" ", words);
            //}

            // get modulo value
            var mod = words.Count - 1;
            var whitespace = rowLength - words.Sum(w => w.Length);

            for(int i = 0; i < whitespace; i++)
            {
                words[i % mod] += " ";
            }

            foreach(var word in words)
            {
                paddedRow.Append(word);
            }

            return paddedRow.ToString();
        }
    }
}

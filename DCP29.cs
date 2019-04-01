using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #29
    Run-length encoding is a fast and simple method of encoding strings. 
    The basic idea is to represent repeated successive characters as a single count and character. 
    For example, the string "AAAABBBCCDAA" would be encoded as "4A3B2C1D2A".

    Implement run-length encoding and decoding. You can assume the string to be encoded have no digits and consists solely of alphabetic characters. You can assume the string to be decoded is valid.
*/
namespace DCP29
{
    public class DCP29
    {
        public static void Main(string[] args)
        {
            var text = "AAAABBBCCDAA";

            text = Encode(text);

            Console.WriteLine($"Encoded text: {text}");

            Console.WriteLine($"Decoded text: {Decode(text)}");
        }

        public static string Encode(string letters)
        {
            if(letters.Length == 0)
            {
                return string.Empty;
            }

            var encodedText = new StringBuilder();
            var currChar = letters[0];
            var count = 1;

            for (int i = 1; i < letters.Length; i++)
            {
                if(currChar != letters[i])
                {
                    encodedText.Append(count);
                    encodedText.Append(currChar);
                    currChar = letters[i];
                    count = 1;
                }
                else
                {
                    count++;
                }
            }

            encodedText.Append(count);
            encodedText.Append(currChar);

            return encodedText.ToString();
        }

        public static string Decode(string letters)
        {
            if(letters.Length == 0)
            {
                return string.Empty;
            }

            var decodedText = new StringBuilder();
            for(int i = 0; i < letters.Length - 1; i += 2)
            {
                int.TryParse(letters[i].ToString(), out int count);

                decodedText.Append(letters[i + 1], count);
            }

            return decodedText.ToString();
        }
    }
}

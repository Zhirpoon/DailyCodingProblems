using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #7
    Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.

    For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.

    You can assume that the messages are decodable. For example, '001' is not allowed. 
*/
namespace DCP7
{
    public class DCP7
    {
        // all combinations of messages
        private static HashSet<string> messages = new HashSet<string>();

        private static void Decode(string message, string remaining)
        {
            if(remaining.Length == 0)
            {
                if (!messages.Contains(message) && !string.IsNullOrWhiteSpace(message))
                {
                    // add to collection
                    messages.Add(message);
                }
                else
                {
                    Console.WriteLine(message);
                }

                // exit
                return;
            }

            // take the first number
            int.TryParse(remaining[0].ToString(), out int firstNumber);

            if(firstNumber >= 1 && firstNumber <= 26)
            {
                Decode(message + NumberToLetter(firstNumber), remaining.Substring(1));
            }

            // take the two first numbers if possible
            if(remaining.Length > 1)
            {
                int.TryParse(remaining.Substring(0,2), out int twoNumbers);

                if(twoNumbers >= 1 && twoNumbers <= 26)
                {
                    Decode(message + NumberToLetter(twoNumbers), remaining.Substring(2));
                }
            }
        }

        // this is not necessary to be able to count the number of combinations but it makes it more pleasing
        private static char NumberToLetter(int c)
        {
            return (char)(c + 96);
        }

        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine();

            Decode("", numbers);

            Console.WriteLine($"There are {messages.Count} ways to decode the message");
        }
    }
}

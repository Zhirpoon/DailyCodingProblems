using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #25
    Implement regular expression matching with the following special characters:
        . (period) which matches any single character
        * (asterisk) which matches zero or more of the preceding element
    
    That is, implement a function that takes in a string and a valid regular expression and returns whether or not the string matches the regular expression.

    For example, given the regular expression "ra." and the string "ray", your function should return true. The same regular expression on the string "raymond" should return false.

    Given the regular expression ".*at" and the string "chat", your function should return true. The same regular expression on the string "chats" should return false.
*/
namespace DCP25
{
    public class DCP25
    {
        public static void Main(string[] args)
        {
            var text11 = "ray";
            var text12 = "raymond";
            var regex1 = "ra.";

            Console.WriteLine($"The text {text11} returns {Match(regex1, text11)} for regex \"{regex1}\"");
            Console.WriteLine($"The text {text12} returns {Match(regex1, text12)} for regex \"{regex1}\"");

            var text21 = "chat";
            var text22 = "chats";
            var regex2 = ".*at";

            Console.WriteLine($"The text {text21} returns {Match(regex2, text21)} for regex \"{regex2}\"");
            Console.WriteLine($"The text {text22} returns {Match(regex2, text22)} for regex \"{regex2}\"");
        }

        public static bool Match(string regex, string text)
        {
            if (regex.Length == 0 && text.Length == 0)
            {
                return true;
            }

            if ((regex.Length == 0 && text.Length != 0) || (regex.Length != 0 && text.Length == 0))
            {
                return false;
            }

            if (regex.StartsWith("*"))
            {
                if (regex.Length > 1)
                {
                    var result = false;
                    for (int i = 1; i < text.Length && !result; i++)
                    {
                        if (Match(regex.Substring(1), text.Substring(i)))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }

            if (regex[0] == text[0] || regex[0] == '.')
            {
                return Match(regex.Substring(1), text.Substring(1));
            }

            return false;
        }
    }
}

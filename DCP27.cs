using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #27
    Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).

    For example, given the string "([])[]({})", you should return true.

    Given the string "([)]" or "((()", you should return false.
*/
namespace DCP27
{
    public class DCP27
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the parenthesis string");
            var text = Console.ReadLine();

            Console.WriteLine($"The text: {text} is {(IsBalanced(text) ? string.Empty : "not")} balanced");
        }

        public static bool IsBalanced(string text)
        {
            var stack = new Stack<char>();

            foreach(var c in text)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                        if(stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if (stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return !(stack.Count > 0);
        }
    }
}

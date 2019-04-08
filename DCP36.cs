using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #36
    Given the root to a binary search tree, find the second largest node in the tree.
*/
namespace DCP36
{
    public class DCP36
    {
        public class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value;
            public Node Left;
            public Node Right;
        }

        public static void Main(string[] args)
        {
            var left = new Node(3)
            {
                Left = new Node(1),
                Right = new Node(6)
                {
                    Left = new Node(4),
                    Right = new Node(7)
                }
            };

            var right = new Node(10)
            {
                Right = new Node(14)
                {
                    Left = new Node(13)
                }
            };

            var root = new Node(8)
            {
                Left = left,
                Right = right
            };

            Console.WriteLine($"The second largest value in the tree is: {GetSecondLargestValue(root)}");
        }

        public static int GetSecondLargestValue(Node root)
        {
            if (root == null)
            {
                throw new Exception("No binary tree given");
            }

            if(root.Right == null && root.Left == null)
            {
                throw new Exception("There is no second largest value as the tree is only one node, the root.");
            }
            
            var curr = root;

            if(curr.Right != null)
            {
                Node prev = curr;
                curr = curr.Right;

                while (curr.Right != null)
                {
                    prev = curr;
                    curr = curr.Right;
                }

                // if curr does not have a left leaf then the second largest value is curr's parent
                return curr.Left?.Value ?? prev.Value;
            }
            else
            {
                curr = curr.Left;

                while(curr.Right != null)
                {
                    curr = curr.Right;
                }

                // return largest value of left side of the tree
                return curr.Value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #8
    A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.

    Given the root to a binary tree, count the number of unival subtrees.

    For example, the following tree has 5 unival subtrees:

       0
      / \
     1   0
        / \
       1   0
      / \
     1   1
*/
namespace DCP8
{
    public class DCP8
    {
        private static int count = 0;

        public class Node
        {
            public Node(int value, Node left = null, Node right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }

            public int Value;
            public Node Left;
            public Node Right;
        }

        public static void UnivalCount(Node node)
        {
            if(node == null)
            {
                return;
            }
            if((node.Left == null && node.Right == null) || node.Left.Value == node.Right.Value)
            {
                count++;
            }

            UnivalCount(node.Left);
            UnivalCount(node.Right);
        }

        public static void Main(string[] args)
        {
            Node root = new Node(0, 
                new Node(1), 
                new Node(0, 
                    new Node(1, 
                        new Node(1), 
                        new Node(1)), 
                    new Node(0)));

            UnivalCount(root);

            Console.WriteLine(count);
        }
    }
}

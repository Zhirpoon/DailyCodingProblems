using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    #3
    Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.

    For example, given the following Node class

    class Node :
        def __init__(self, val, left=None, right=None):
            self.val = val
            self.left = left
            self.right = right
    The following test should pass:

    node = Node('root', Node('left', Node('left.left')), Node('right'))
    assert deserialize(serialize(node)).left.left.val == 'left.left'
*/

namespace DCP3
{
    // Node implementation to be used 
    public class Node
    {
        public Node(string val, Node left = null, Node right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }

        public string Val;
        public Node Right;
        public Node Left;
    }

    public class DCP3
    {
        public static void Main(string[] args)
        {
            var node = new Node("root", new Node("left", new Node("left.left")), new Node("right"));
            Console.WriteLine(Deserialize(Serialize(node)).Left.Left.Val);
        }

        // make tree into string recursively
        public static string Serialize(Node node)
        {
            if (node == null)
            {
                return "null;";
            }

            var sb = new StringBuilder();

            sb.Append($"{node.Val};");

            sb.Append(Serialize(node.Left));

            sb.Append(Serialize(node.Right));

            return sb.ToString();
        }

        // make string into Node tree
        public static Node Deserialize(string s)
        {
            var nodes = s
                .Split(';')
                .ToList();

            // create queue for easier removing of values in recursion
            var queue = new Queue<string>(nodes);

            var node = DeserializeNode(queue);

            return node;
        }

        // recursively build Node tree
        public static Node DeserializeNode(Queue<string> nodes)
        {
            if(nodes.Peek() != null)
            {
                var nextNode = nodes.Dequeue();

                if(nextNode == "null")
                {
                    return null;
                }

                var node = new Node(nextNode)
                {
                    Left = DeserializeNode(nodes),
                    Right = DeserializeNode(nodes)
                };

                return node;
            }

            return null;
        }
    }
}

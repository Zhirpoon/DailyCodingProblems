using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #24
    Implement locking in a binary tree. A binary tree node can be locked or unlocked only if all of its descendants or ancestors are not locked.

    Design a binary tree node class with the following methods:
        is_locked, which returns whether the node is locked
        lock, which attempts to lock the node. If it cannot be locked, then it should return false. Otherwise, it should lock it and return true.
        unlock, which unlocks the node. If it cannot be unlocked, then it should return false. Otherwise, it should unlock it and return true.

    You may augment the node to add parent pointers or any other property you would like. You may assume the class is used in a single-threaded program, so there is no need for actual locks or mutexes. 
    Each method should run in O(h), where h is the height of the tree.
*/
namespace DCP24
{
    public class DCP24
    {
        public class Node
        {
            public Node()
            {
            }

            public Node(bool isLocked)
            {
                this.isLocked = isLocked;
            }

            public void AddLeft(Node node)
            {
                left = node;
                node.parent = this;
            }

            public void AddRight(Node node)
            {
                right = node;
                node.parent = this;
            }

            public Node left;
            public Node right;
            private Node parent;
            private bool isLocked;

            public bool IsLocked()
            {
                return isLocked;
            }

            public bool Lock()
            {
                if(!AscendantsLocked(parent) && !DescendantsLocked(left) && !DescendantsLocked(right))
                {
                    isLocked = true;
                    return true;
                }
                return false;
            }

            public bool Unlock()
            {
                if (!AscendantsLocked(parent) && !DescendantsLocked(left) && !DescendantsLocked(right))
                {
                    isLocked = false;
                    return true;
                }
                return false;
            }

            public bool AscendantsLocked(Node node, bool isLocked = false)
            {
                if (node == null || isLocked)
                {
                    return isLocked;
                }

                return AscendantsLocked(node.parent, node.IsLocked());
            }

            public bool DescendantsLocked(Node node, bool isLocked = false)
            {
                if (node == null || isLocked)
                {
                    return isLocked;
                }

                return DescendantsLocked(node.left, node.IsLocked()) || DescendantsLocked(node.right, node.IsLocked());
            }
        }

        public static void Main(string[] args)
        {
            var root = new Node(false);

            root.AddLeft(new Node(false));
            root.AddRight(new Node(false));
            root.right.AddRight(new Node(true));
            root.right.AddLeft(new Node(false));
            root.left.AddLeft(new Node(false));
            root.left.AddRight(new Node(false));

            var worked = root.left.left.Lock() ? "Locking worked" : "Locking didn't work";

            Console.WriteLine($"{worked} the value node is now {(root.left.left.IsLocked() ? "locked" : "unlocked")}");
        }
    }
}

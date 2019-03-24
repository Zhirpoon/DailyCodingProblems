using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #20
    Given two singly linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.

    For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8.

    In this example, assume nodes with the same value are the exact same node objects.

    Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space.
*/
namespace DCP20
{
    public class DCP20
    {
        public class SinglyLinkedList
        {
            public SinglyLinkedList()
            {
            }

            public SinglyLinkedList(int value)
            {
                Value = value;
            }

            public SinglyLinkedList(int value, SinglyLinkedList next)
            {
                Next = next;
                Value = value;
            }

            public int Value;

            public SinglyLinkedList Next;
        }

        public static void Main(string[] args)
        {
            var a = new SinglyLinkedList(1,
                new SinglyLinkedList(6,
                new SinglyLinkedList(9,
                new SinglyLinkedList(15,
                new SinglyLinkedList(31)))));

            var b = new SinglyLinkedList(1,
                new SinglyLinkedList(11,
                new SinglyLinkedList(30)));

            var result = GetNode(a, b);

            Console.WriteLine(result.HasValue ? result.Value.ToString() : "Nothing");
        }

        // O(N*M) with constant space
        public static int? FindIntersectionA(SinglyLinkedList a, SinglyLinkedList b)
        {
            var tempB = b;
            while (a.Next != null)
            {
                while (tempB.Next != null)
                {
                    if (a.Value == tempB.Value)
                    {
                        return tempB.Value;
                    }

                    tempB = tempB.Next;
                }

                a = a.Next;
                tempB = b;
            }

            return null;
        }

        // O(N + M) with constant space
        public static int? GetNode(SinglyLinkedList rootA, SinglyLinkedList rootB)
        {
            var countA = GetCount(rootA);
            var countB = GetCount(rootB);

            if (countA > countB)
            {
                var diff = countA - countB;
                return GetIntersectingNode(diff, rootA, rootB);
            }
            else
            {
                var diff = countB - countA;
                return GetIntersectingNode(diff, rootB, rootA);
            }
        }

        public static int GetCount(SinglyLinkedList node)
        {
            SinglyLinkedList current = node;
            var count = 0;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public static int? GetIntersectingNode(int diff, SinglyLinkedList root1, SinglyLinkedList root2)
        {
            SinglyLinkedList current1 = root1;
            SinglyLinkedList current2 = root2;

            for(int i = 0; i < diff; i++)
            {
                if(current1 == null)
                {
                    return null;
                }
                current1 = current1.Next;
            }
            while(current1 != null && current2 != null)
            {
                if(current1.Value == current2.Value)
                {
                    return current1.Value;
                }
                current1 = current1.Next;
                current2 = current2.Next;
            }

            return null;
        }
    }
}

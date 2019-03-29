using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #26
    Given a singly linked list and an integer k, remove the kth last element from the list. k is guaranteed to be smaller than the length of the list.

    The list is very long, so making more than one pass is prohibitively expensive.

    Do this in constant space and in one pass.
*/
namespace DCP26
{
    public class DCP26
    {
        public class SinglyLinkedList
        {
            public Node Root;
            public int Count;
            public class Node
            {
                public Node()
                {
                }

                public Node(int value, Node previous = null)
                {
                    Value = value;
                    if(previous != null)
                    {
                        previous.Next = this;
                    }
                }

                public Node Next;
                public int Value;
            }

            public void Add(int value)
            {
                if(Root == null)
                {
                    Count = 0;
                    Root = new Node(value);
                }
                else
                {
                    var current = Root;
                    var previous = (Node)null;

                    while(current != null)
                    {
                        previous = current;
                        current = current.Next;
                    }

                    current = new Node(value, previous);
                }

                Count++;
            }
        }
        


        public static void Main(string[] args)
        {
            var list = new SinglyLinkedList();

            for(int i = 1; i <= 7000; i++)
            {
                list.Add(i);
            }

            Console.WriteLine("Which element in the list do you want to remove?");
            int.TryParse(Console.ReadLine(), out int k);

            var res = RemoveKthLastElement(k, list);

            Console.WriteLine($"Removed node with value: {res}.");
        }

        public static int RemoveKthLastElement(int k, SinglyLinkedList list)
        {
            var steps = list.Count - k;

            var current = list.Root;
            var previous = (SinglyLinkedList.Node)null;

            while(steps > 0)
            {
                previous = current;
                current = current.Next;
                steps--;
            }

            previous.Next = current.Next;

            list.Count--;
            return current.Value;
        }
    }
}

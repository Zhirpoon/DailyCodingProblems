using System;
using System.Collections.Generic;
/*
    #6
    An XOR linked list is a more memory efficient doubly linked list. 
    Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node. 
    Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.

    If using a language that has no pointers (such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
*/
/*
	Example of calculating both(easier understood in binary):
	0 = 0
	1 = 1
	
	0 XOR 1 = 1 = 1
	
	1 = 01
	2 = 10
	
	1 XOR 2 = 11 = 3

	3 = 11
	1 = 01
	
	3 XOR 1 = 10 = 2

*/
namespace DCP6
{
    public class XORLinkedList<T>
    {
        private XORNode Head;

        // use integers to store addresses as pointers aren't safe in C#
        private int address = 1;

        private Dictionary<int, XORNode> positions = new Dictionary<int, XORNode>();

        public class XORNode
        {
            public int Both { get; set; }
            public int Address { get; set; }
            public T Value { get; set; }
        }

        public void Add(T element)
        {
            if(Head == null)
            {
                Head = new XORNode()
                {
                    Value = element,
                    Address = address,
                    Both = 0
                };

                positions.Add(Head.Address, Head);
            }
            else
            {
                var current = Head;
                var previous = (XORNode)null;

                while (true)
                {
                    var currentAddress = (current.Both) ^ (previous == null ? 0 : previous.Address);

                    if(currentAddress == 0)
                    {
                        break;
                    }

                    previous = current;
                    current = positions[currentAddress];
                }

                var node = new XORNode
                {
                    Value = element,
                    Both = 0 ^ current.Address,
                    Address = address
                };

                current.Both = node.Address ^ (previous == null ? 0 : previous.Address);

                positions.Add(node.Address, node);
            }

            address++;
        }

        public T Get(int index)
        {
            var current = Head;
            var previous = (XORNode)null;

            for(int i = 0; i < index; i++)
            {
                var nextAddress = current.Both ^ (previous == null ? 0 : previous.Address);

                previous = current;

                if (!positions.ContainsKey(nextAddress))
                {
                    return default(T);
                }

                current = positions[nextAddress];
            }

            return current.Value;
        }
    }

    class DCP6
    {
        public static void Main(string[] args)
        {
            var xorLinkedList = new XORLinkedList<int>();

            for(int i = 0; i <= 10; i++)
            {
                xorLinkedList.Add(i);
            }

            Console.WriteLine(xorLinkedList.Get(79));
        }
    }
}

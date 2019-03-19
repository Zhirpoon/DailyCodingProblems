using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #16
    You run an e-commerce website and want to record the last N order ids in a log. Implement a data structure to accomplish this, with the following API:
        record(order_id): adds the order_id to the log
        get_last(i): gets the ith last element from the log. i is guaranteed to be smaller than or equal to N.
    You should be as efficient with time and space as possible.
*/
namespace DCP16
{
    public class DCP16
    {
        public class Log
        {
            public Log(int limit)
            {
                this.limit = limit;
            }

            private readonly LinkedList<int> storage = new LinkedList<int>();
            private int limit = 0;

            public void Record(int orderId)
            {
                if(storage.Count == limit)
                {
                    storage.RemoveFirst();
                }

                storage.AddLast(orderId);
            }

            public int GetLast(int fromLast)
            {
                var last = storage.Last;

                while(fromLast > 0)
                {
                    last = last.Previous;
                    fromLast--;
                }

                return last.Value;
            }

        }

        public static void Main(string[] args)
        {
            Console.WriteLine("How many order ids should be stored?");
            int.TryParse(Console.ReadLine(), out int limit);
            Log log = new Log(limit);

            for(int i = 0; i < 5; i++)
            {
                log.Record(i);
            }

            Console.WriteLine("what ith last position do you want?");
            int.TryParse(Console.ReadLine(), out int ith);
            Console.WriteLine(log.GetLast(ith));
        }
    }
}

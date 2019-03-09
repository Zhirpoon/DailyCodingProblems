using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #5
    cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair. For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.

    Given this implementation of cons:

    def cons(a, b):
        def pair(f):
            return f(a, b)
        return pair
    Implement car and cdr.
*/
namespace DCP5
{
    class DCP5
    {
        public static Tuple<int, int> Cons(int a, int b)
        {
            // define pair
            Func<int, int, Tuple<int, int>> pair = Tuple.Create;

            return pair(a, b);
        }

        // returns first element
        public static int Car(Tuple<int, int> tuple)
        {
            return tuple.Item1;
        }

        // returns last element
        public static int Cdr(Tuple<int, int> tuple)
        {
            return tuple.Item2;
        }


        public static void Main(string[] args)
        {
            Console.WriteLine(Car(Cons(3, 4)));
            Console.WriteLine(Cdr(Cons(3, 4)));
        }
    }
}

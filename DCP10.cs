using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    #10
    Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
*/
namespace DCP10
{
    public class DCP10
    {
        public static void JobScheduler(Func<string> f, int delay)
        {
            Thread.Sleep(delay);
            Console.WriteLine($"delayed {f.Invoke()} by {delay} milliseconds");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Type the amount of delay you want in milliseconds");
            int.TryParse(Console.ReadLine(), out int delay);

            Func<string> writeFunction = () => "function";

            JobScheduler(writeFunction, delay);
        }
    }
}

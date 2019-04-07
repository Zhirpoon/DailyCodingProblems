using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #35   
    Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. 
    You can only swap elements of the array.

    Do this in linear time and in-place.

    For example, given the array ['G', 'B', 'R', 'R', 'B', 'R', 'G'], it should become ['R', 'R', 'R', 'G', 'G', 'B', 'B'].
*/
namespace DCP35
{
    public class DCP35
    {
        public static void Main(string[] args)
        {
            var array = new char[] { 'G', 'B', 'R', 'R', 'B', 'R', 'G' };

            Console.WriteLine($"The sorted array is: [{string.Join(", ", SortArray(array))}]");
        }

        public static char[] SortArray(char[] array)
        {
            // create sorting order characters
            var characters = new char[] { 'R', 'G', 'B' };

            // create placement index and temp character holder
            var placementIndex = 0;
            char swapped;

            // loop each character
            foreach(var c in characters)
            {
                // check characters
                for (int i = placementIndex; i < array.Length; i++)
                {
                    if (array[i] == c)
                    {
                        // swap placements
                        swapped = array[placementIndex];
                        array[placementIndex] = array[i];
                        array[i] = swapped;
                        placementIndex++;
                    }
                }
            }

            return array;
        }
    }
}

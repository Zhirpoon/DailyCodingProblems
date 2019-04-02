using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #30
    You are given an array of non-negative integers that represents a two-dimensional elevation map where each element is unit-width wall and the integer is the height. 
    Suppose it will rain and all spots between two walls get filled up.

    Compute how many units of water remain trapped on the map in O(N) time and O(1) space.

    For example, given the input [2, 1, 2], we can hold 1 unit of water in the middle.

    Given the input [3, 0, 1, 3, 0, 5], we can hold 3 units in the first index, 2 in the second, and 3 in the fourth index (we cannot hold 5 since it would run off to the left), so we can trap 8 units of water.
*/
namespace DCP30
{
    public class DCP30
    {
        public static void Main(string[] args)
        {
            var heights = new int[] { 3, 0, 1, 3, 0, 5 };

            Console.WriteLine($"The amount of filled water is: {GetFilledWaterTotal(heights)}");
        }

        public static int GetFilledWaterTotal(int[] heights)
        {
            var currLeft = 0;
            var currRight = heights.Length - 1;

            var leftMaxHeight = -1;
            var rightMaxHeight = -1;

            var filledWater = 0;

            while(currLeft < currRight)
            {
                if(heights[currLeft] < heights[currRight])
                {
                    if(heights[currLeft] >= leftMaxHeight)
                    {
                        leftMaxHeight = heights[currLeft];
                    }
                    else
                    {
                        filledWater += leftMaxHeight - heights[currLeft];
                    }
                    currLeft++;
                }
                else
                {
                    if(heights[currRight] >= rightMaxHeight)
                    {
                        rightMaxHeight = heights[currRight];
                    }
                    else
                    {
                        filledWater += rightMaxHeight - heights[currRight];
                    }
                    currRight--;
                }
            }

            return filledWater;
        }
    }
}

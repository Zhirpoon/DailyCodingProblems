using System;
using System.Collections.Generic;
using System.Linq;
/*		
	#4
	Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.

	For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

	You can modify the input array in-place.
*/	
public class DCP4
{
	public static void Main()
	{
		int missingNumber = 1;
		
		List<int> numbers = Console.ReadLine()
			.Split(' ')
			.Select(int.Parse)
			.ToList();
		
		var ordered = numbers = numbers.OrderBy(x => x)
			.ToList();
		
		Console.WriteLine(string.Join(" ", ordered));
		
		var minList = numbers.Where(n => n > 0);
		
		if(minList.Count() != 0 && minList.Min() <= missingNumber)
		{
			foreach(var n in minList)
			{
				if(!minList.Any(x => x == n+1))
				{
					missingNumber = n+1;
					break;
				}
			}
		}
		
		Console.WriteLine(missingNumber);
	}
}
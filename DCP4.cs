using System;
using System.Collections.Generic;
using System.Linq;
					
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
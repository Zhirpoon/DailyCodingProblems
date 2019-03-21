using System;
using System.Linq;
/*
	#15
	Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.

	reservoir sampling to guarantee uniformity
*/
public class DCP15
{
	static int result = 0;
	static int count = 0;
	
	public static int Random(int x)
	{
		count++;
		
		if(count == 1)
		{
			result = x;
		}	
		else
		{
			Random r = new Random();
			int i = r.Next(count);
			
			if(i == count -1)
			{
				result = x;
			}
		}
		
		return result;
	}
	
	public static void Main()
	{
		var stream = Console.ReadLine()
			.Split(' ')
			.Select(int.Parse)
			.ToArray();
		
		var n = stream.Length;
		
		// show uniformly sampled values
		for(int i = 0; i < n; i++)
		{
			Console.WriteLine(Random(stream[i]));
		}
	}
}
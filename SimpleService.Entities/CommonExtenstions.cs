using System;

namespace SimpleService.Entities
{
	public static class CommonExtenstions
	{
		public static double NextDouble(this Random random, double min, double max)
		{
			return random.NextDouble() * Math.Abs(min - max) + Math.Min(min, max);
		}
	}
}
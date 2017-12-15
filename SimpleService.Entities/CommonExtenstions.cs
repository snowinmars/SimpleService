using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

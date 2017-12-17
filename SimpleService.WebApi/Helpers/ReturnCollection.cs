using System.Collections.Generic;

namespace SimpleService.WebApi
{
	public class ReturnCollection<T>
	{
		public IEnumerable<T> Data { get; set; }
	}
}
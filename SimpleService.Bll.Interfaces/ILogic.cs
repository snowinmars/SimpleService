using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Bll.Interfaces
{
	public interface ILogic<T>
	{
		Func<T, bool> DefaultFilter { get; }

		Task<T> Get(int id);

		Task<IEnumerable<T>> Get(Func<T, bool> filter);
	}
}
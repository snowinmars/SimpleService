using System;
using System.Collections.Generic;

namespace SimpleService.Bll.Interfaces
{
	public interface ILogic<T>
	{
		T Get(int id);

		IEnumerable<T> Get(Func<T, bool> filter);

		Func<T, bool> DefaultFilter { get; }
	}
}
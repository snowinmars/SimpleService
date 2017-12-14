using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleService.Entities;

namespace SimpleService.Bll.Interfaces
{
	public interface ILogic<T>
	{
		Task<T> Get(int id);

		Task<IEnumerable<T>> Get(Func<T, bool> filter);

		Func<T, bool> DefaultFilter { get; }
	}
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleService.Entities;

namespace SimpleService.Bll.Interfaces
{
	public interface ILogic<T>
	{
		Func<T, bool> DefaultFilter { get; }

		Task<T> GetAsync(int id);

		Task<Page<T>> GetAsync(Func<T, bool> filter, PageInfo pageInfo);
	}
}
using SimpleService.Entities;
using System;
using System.Threading.Tasks;

namespace SimpleService.Bll.Interfaces
{
	public interface ILogic<T>
	{
		Func<T, bool> DefaultFilter { get; }

		Task<T> GetAsync(int id);

		Task<Page<T>> GetAsync(Func<T, bool> filter, PageInfo pageInfo);
	}
}
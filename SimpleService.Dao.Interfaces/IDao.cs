using SimpleService.Entities;
using System;
using System.Threading.Tasks;

namespace SimpleService.Dao.Interfaces
{
	public interface IDao<T>
	{
		Task<T> GetAsync(int id);

		Task<Page<T>> GetAsync(Func<T, bool> filter, PageInfo pageInfo);
	}
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleService.Entities;

namespace SimpleService.Dao.Interfaces
{
	public interface IDao<T>
	{
		Task<T> GetAsync(int id);

		Task<Page<T>> GetAsync(Func<T, bool> filter, PageInfo pageInfo);
	}
}
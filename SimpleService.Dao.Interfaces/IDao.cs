using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Dao.Interfaces
{
	public interface IDao<T>
	{
		Task<T> GetAsync(int id);

		Task<IEnumerable<T>> GetAsync(Func<T, bool> filter);
	}
}
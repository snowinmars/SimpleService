using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleService.Entities;

namespace SimpleService.Dao.Interfaces
{
	public interface IDao<T>
	{
		T Get(int id);

		IEnumerable<Album> Get(Func<T, bool> filter);
	}
}
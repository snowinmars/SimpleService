﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Dao.Interfaces
{
	public interface IDao<T>
	{
		Task<T> Get(int id);

		Task<IEnumerable<T>> Get(Func<T, bool> filter);
	}
}
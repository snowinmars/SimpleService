﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Bll.Interfaces
{
	public interface ILogic<T>
	{
		Func<T, bool> DefaultFilter { get; }

		Task<T> GetAsync(int id);

		Task<IEnumerable<T>> GetAsync(Func<T, bool> filter);
	}
}
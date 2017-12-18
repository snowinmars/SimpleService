using SimpleService.Bll.Interfaces;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Bll
{
	public class UserLogic : IUserLogic
	{
		private readonly IUserDao dao;

		public UserLogic(IUserDao dao)
		{
			this.dao = dao;
			this.DefaultFilter = user => true;
		}

		public Func<User, bool> DefaultFilter { get; }

		public Task<User> GetAsync(int id)
		{
			return this.dao.GetAsync(id);
		}

		public Task<Page<User>> GetAsync(Func<User, bool> filter, PageInfo pageInfo)
		{
			return this.dao.GetAsync(filter, pageInfo);
		}

		public Task<Page<Album>> GetAlbumsAsync(int userId, PageInfo pageInfo)
		{
			return this.dao.GetAlbumsAsync(userId, pageInfo);
		}
	}
}
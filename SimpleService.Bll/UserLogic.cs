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

		public Task<User> Get(int id)
		{
			return this.dao.Get(id);
		}

		public Task<IEnumerable<User>> Get(Func<User, bool> filter)
		{
			return this.dao.Get(filter);
		}

		public Task<IEnumerable<Album>> GetAlbums(int userId)
		{
			return this.dao.GetAlbums(userId);
		}
	}
}
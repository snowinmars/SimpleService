using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleService.Bll.Interfaces;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;

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

		public Task<User> Get(int id)
		{
			return this.dao.Get(id);
		}

		public Func<User, bool> DefaultFilter { get; }

		public Task<IEnumerable<Album>> GetAlbums(int userId)
		{
			return this.dao.GetAlbums(userId);
		}

		public Task<IEnumerable<User>> Get(Func<User, bool> filter)
		{
			return this.dao.Get(filter);
		}
	}
}

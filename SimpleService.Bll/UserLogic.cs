using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleService.Bll.Interfaces;
using SimpleService.Entities;

namespace SimpleService.Bll
{
	public class UserLogic : IUserLogic
	{
		public UserLogic()
		{
			this.DefaultFilter = user => true;
		}

		public User Get(int id)
		{
			throw new NotImplementedException();
		}

		public Func<User, bool> DefaultFilter { get; }

		public IEnumerable<Album> GetAlbums(int userId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> Get(Func<User, bool> filter)
		{
			throw new NotImplementedException();
		}
	}
}

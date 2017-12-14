using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;

namespace SimpleService.Dao
{
    public class UserDao : IUserDao
    {
	    public User Get(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public IEnumerable<Album> GetAlbums(int userId)
	    {
		    throw new NotImplementedException();
	    }

	    public IEnumerable<Album> Get(Func<User, bool> filter)
	    {
		    throw new NotImplementedException();
	    }
    }
}

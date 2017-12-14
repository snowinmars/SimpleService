using System.Collections.Generic;
using SimpleService.Entities;

namespace SimpleService.Dao.Interfaces
{
	public interface IUserDao : IDao<User>
	{
		IEnumerable<Album> GetAlbums(int userId);
	}
}
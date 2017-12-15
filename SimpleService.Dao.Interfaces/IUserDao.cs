using SimpleService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Dao.Interfaces
{
	public interface IUserDao : IDao<User>
	{
		Task<IEnumerable<Album>> GetAlbums(int userId);
	}
}
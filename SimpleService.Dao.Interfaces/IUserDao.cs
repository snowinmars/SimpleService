using SimpleService.Entities;
using System.Threading.Tasks;

namespace SimpleService.Dao.Interfaces
{
	public interface IUserDao : IDao<User>
	{
		Task<Page<Album>> GetAlbumsAsync(int userId, PageInfo pageInfo);
	}
}
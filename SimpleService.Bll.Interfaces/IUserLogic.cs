using SimpleService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Bll.Interfaces
{
	public interface IUserLogic : ILogic<User>
	{
		Task<Page<Album>> GetAlbumsAsync(int userId, PageInfo pageInfo);
	}
}
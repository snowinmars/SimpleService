using SimpleService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Bll.Interfaces
{
	public interface IUserLogic : ILogic<User>
	{
		Task<IEnumerable<Album>> GetAlbumsAsync(int userId);
	}
}
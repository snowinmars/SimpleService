using SimpleService.Entities;
using System.Collections.Generic;

namespace SimpleService.Bll.Interfaces
{
	public interface IUserLogic : ILogic<User>
	{
		IEnumerable<Album> GetAlbums(int userId);
	}
}
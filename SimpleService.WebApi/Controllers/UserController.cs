using Newtonsoft.Json;
using SimpleService.Bll.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	public class UserController : ApiController
	{
		private readonly IUserLogic logic;

		public UserController(IUserLogic logic)
		{
			this.logic = logic;
		}

		// GET: api/User
		public async Task<IEnumerable<string>> Get()
		{
			var users = await this.logic.Get(this.logic.DefaultFilter);

			return users.Select(JsonConvert.SerializeObject).ToList();
		}

		// GET: api/User/5
		public string Get(int id)
		{
			var user = this.logic.Get(id);

			return JsonConvert.SerializeObject(user);
		}

		// GET: api/UsersAlbuns/5
		public async Task<IEnumerable<string>> GetAlbums(int userId)
		{
			var albums = await this.logic.GetAlbums(userId);

			return albums.Select(JsonConvert.SerializeObject).ToList();
		}
	}
}
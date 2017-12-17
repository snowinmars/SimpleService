using Newtonsoft.Json;
using SimpleService.Bll.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	[RoutePrefix("api/user")]
	public class UserController : ApiController
	{
		private readonly IUserLogic logic;

		public UserController(IUserLogic logic)
		{
			this.logic = logic;
		}

		// GET: api/User
		[HttpGet]
		public async Task<IEnumerable<string>> Get()
		{
			var users = await this.logic.GetAsync(this.logic.DefaultFilter);

			return users.Select(u => JsonConvert.SerializeObject(u, Formatting.Indented)).ToList();
		}

		// GET: api/User/5
		[HttpGet]
		public async Task<string> Get(int id)
		{
			var user = this.logic.GetAsync(id);

			return JsonConvert.SerializeObject(await user, Formatting.Indented);
		}

		// GET: api/User/GetAlbums/5
		[HttpGet]
		[Route("getAlbums/{userId}")]
		public async Task<IEnumerable<string>> GetAlbums(int userId)
		{
			var albums = await this.logic.GetAlbumsAsync(userId);

			return albums.Select(a => JsonConvert.SerializeObject(a, Formatting.Indented)).ToList();
		}
	}
}
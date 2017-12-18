using SimpleService.Bll.Interfaces;
using SimpleService.Entities;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	[RoutePrefix("api/v1/users")]
	public class UsersController : BaseController
	{
		private readonly IUserLogic logic;

		public UsersController(IUserLogic logic)
		{
			this.logic = logic;
		}

		// GET: api/Users
		[HttpGet]
		public async Task<string> Get([FromUri]PageInfo pageInfo)
		{
			var users = this.logic.GetAsync(this.logic.DefaultFilter, pageInfo);

			return this.Serialize(await users);
		}

		// GET: api/Users/5
		[HttpGet]
		public async Task<string> Get(int id)
		{
			var user = this.logic.GetAsync(id);

			return this.Serialize(await user);
		}

		// GET: api/Users/GetAlbums/5
		[HttpGet]
		[Route("getAlbums/{userId}")]
		public async Task<string> GetAlbums(int userId, [FromUri]PageInfo pageInfo)
		{
			var albums = this.logic.GetAlbumsAsync(userId, pageInfo);

			return this.Serialize(await albums);
		}
	}
}
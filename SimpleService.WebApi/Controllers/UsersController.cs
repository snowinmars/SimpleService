using SimpleService.Bll.Interfaces;
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
		public async Task<string> Get()
		{
			var users = this.logic.GetAsync(this.logic.DefaultFilter);

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
		public async Task<string> GetAlbums(int userId)
		{
			var albums = this.logic.GetAlbumsAsync(userId);

			return this.Serialize(await albums);
		}
	}
}
using SimpleService.Bll.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	[RoutePrefix("api/v1/users")]
	public class UserController : BaseController
	{
		private readonly IUserLogic logic;

		public UserController(IUserLogic logic)
		{
			this.logic = logic;
		}

		// GET: api/User
		[HttpGet]
		public async Task<string> Get()
		{
			var users = this.logic.GetAsync(this.logic.DefaultFilter);

			return this.Serialize(await users);
		}

		// GET: api/User/5
		[HttpGet]
		public async Task<string> Get(int id)
		{
			var user = this.logic.GetAsync(id);

			return this.Serialize(await user);
		}

		// GET: api/User/GetAlbums/5
		[HttpGet]
		[Route("getAlbums/{userId}")]
		public async Task<string> GetAlbums(int userId)
		{
			var albums = this.logic.GetAlbumsAsync(userId);

			return this.Serialize(await albums);
		}
	}
}
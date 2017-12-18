using SimpleService.Bll.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	[RoutePrefix("api/v1/albums")]
	public class AlbumsController : BaseController
	{
		private readonly IAlbumLogic logic;

		public AlbumsController(IAlbumLogic logic)
		{
			this.logic = logic;
		}

		// GET: api/Albums
		[HttpGet]
		public async Task<string> Get()
		{
			var albums = this.logic.GetAsync(this.logic.DefaultFilter);

			return this.Serialize(await albums);
		}

		// GET: api/Albums/5
		[HttpGet]
		public async Task<string> Get(int id)
		{
			var album = await this.logic.GetAsync(id);

			return this.Serialize(album);
		}
	}
}
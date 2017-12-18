using SimpleService.Bll.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using SimpleService.Entities;

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
		public async Task<string> Get([FromUri]PageInfo pageInfo)
		{
			var albums = this.logic.GetAsync(this.logic.DefaultFilter, pageInfo);

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
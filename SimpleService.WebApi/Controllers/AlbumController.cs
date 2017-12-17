using Newtonsoft.Json;
using SimpleService.Bll.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	public class AlbumController : ApiController
	{
		private readonly IAlbumLogic logic;

		public AlbumController(IAlbumLogic logic)
		{
			this.logic = logic;
		}

		// GET: api/Album
		[HttpGet]
		public async Task<IEnumerable<string>> Get()
		{
			var albums = await this.logic.GetAsync(this.logic.DefaultFilter);

			return albums.Select(a => JsonConvert.SerializeObject(a, Formatting.Indented)).ToList();
		}

		// GET: api/Album/5
		[HttpGet]
		public async Task<string> Get(int id)
		{
			var album = this.logic.GetAsync(id);

			return JsonConvert.SerializeObject(await album, Formatting.Indented);
		}
	}
}
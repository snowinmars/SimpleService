using Newtonsoft.Json;
using SimpleService.Bll.Interfaces;
using System.Collections.Generic;
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
		public IEnumerable<string> Get()
		{
			var albums = this.logic.Get(this.logic.DefaultFilter);

			foreach (var album in albums)
			{
				yield return JsonConvert.SerializeObject(album);
			}
		}

		// GET: api/Album/5
		public string Get(int id)
		{
			var album = this.logic.Get(id);

			return JsonConvert.SerializeObject(album);
		}
	}
}
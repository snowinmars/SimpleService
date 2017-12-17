﻿using SimpleService.Bll.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	[RoutePrefix("api/v1/albums")]
	public class AlbumController : BaseController
	{
		private readonly IAlbumLogic logic;

		public AlbumController(IAlbumLogic logic)
		{
			this.logic = logic;
		}

		// GET: api/Album
		[HttpGet]
		public async Task<string> Get()
		{
			var albums = this.logic.GetAsync(this.logic.DefaultFilter);

			return this.Serialize(await albums);
		}

		// GET: api/Album/5
		[HttpGet]
		public async Task<string> Get(int id)
		{
			var album = await this.logic.GetAsync(id);

			return this.Serialize(album);
		}
	}
}
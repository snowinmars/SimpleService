using Newtonsoft.Json;
using SimpleService.Bll.Interfaces;
using System.Collections.Generic;
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
		public IEnumerable<string> Get()
		{
			var users = this.logic.Get(this.logic.DefaultFilter);

			foreach (var user in users)
			{
				yield return JsonConvert.SerializeObject(user);
			}
		}

		// GET: api/User/5
		public string Get(int id)
		{
			var user = this.logic.Get(id);

			return JsonConvert.SerializeObject(user);
		}

		// GET: api/UsersAlbuns/5
		public IEnumerable<string> GetAlbums(int userId)
		{
			var albums = this.logic.GetAlbums(userId);

			foreach (var album in albums)
			{
				yield return JsonConvert.SerializeObject(album);
			}
		}
	}
}
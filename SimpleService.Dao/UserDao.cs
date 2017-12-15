using Newtonsoft.Json;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SimpleService.Common;

namespace SimpleService.Dao
{
	public class UserDao : IUserDao
	{
		private readonly HttpClient httpClient;

		public UserDao()
		{
			this.httpClient = new HttpClient();
		}

		public async Task<User> Get(int id)
		{
			string getUserByIdUrl = string.Format(Config.Url.UserByIdFormat, id);

			var urlData = await this.httpClient.GetStringAsync(getUserByIdUrl);

			var collection = JsonConvert.DeserializeObject<InternalEntities.User>(urlData);

			return Mapper.Map(collection);
		}

		public async Task<IEnumerable<User>> Get(Func<User, bool> filter)
		{
			string getAllUsersUrl = Config.Url.Users;

			var urlData = await this.httpClient.GetStringAsync(getAllUsersUrl);

			var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.User>>(urlData);

			return Mapper.Map(collection).Where(filter.Invoke);
		}

		public async Task<IEnumerable<Album>> GetAlbums(int userId)
		{
			string getAllAlbumsForUserUrl = string.Format(Config.Url.AlbumByUserIdFormat, userId);

			var urlData = await this.httpClient.GetStringAsync(getAllAlbumsForUserUrl);

			var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.Album>>(urlData);

			return Mapper.Map(collection);
		}
	}
}
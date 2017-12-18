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

		public async Task<User> GetAsync(int id)
		{
			string getUserByIdUrl = string.Format(Config.Url.UserByIdFormat, id);

			var urlData = this.httpClient.GetStringAsync(getUserByIdUrl);

			var collection = JsonConvert.DeserializeObject<InternalEntities.User>(await urlData);

			return Mapper.Map(collection);
		}

		public async Task<Page<User>> GetAsync(Func<User, bool> filter, PageInfo pageInfo)
		{
			string getAllUsersUrl = Config.Url.Users;

			var urlData = this.httpClient.GetStringAsync(getAllUsersUrl);

			var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.User>>(await urlData);

			var users = Mapper.Map(collection).Where(filter.Invoke).ToList();

			return Page<User>.Pagify(pageInfo, users);
		}

		public async Task<Page<Album>> GetAlbumsAsync(int userId, PageInfo pageInfo)
		{
			string getAllAlbumsForUserUrl = string.Format(Config.Url.AlbumByUserIdFormat, userId);

			var urlData = this.httpClient.GetStringAsync(getAllAlbumsForUserUrl);

			var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.Album>>(await urlData);

			var albums = Mapper.Map(collection).ToList();

			return Page<Album>.Pagify(pageInfo, albums);
		}
	}
}
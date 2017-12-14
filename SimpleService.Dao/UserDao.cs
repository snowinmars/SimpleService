using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;

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
			string getAllAlbumsUrl = $"http://jsonplaceholder.typicode.com/users/{id}";

		    var urlData = await this.httpClient.GetStringAsync(getAllAlbumsUrl);

		    var collection = JsonConvert.DeserializeObject<InternalEntities.User>(urlData);

		    return Mapper.Map(collection);
		}

	    public async Task<IEnumerable<Album>> GetAlbums(int userId)
	    {
			string getAllAlbumsUrl = $"http://jsonplaceholder.typicode.com/albums?userId={userId}";

		    var urlData = await this.httpClient.GetStringAsync(getAllAlbumsUrl);

		    var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.Album>>(urlData);

		    return Mapper.Map(collection);
		}

	    public async Task<IEnumerable<User>> Get(Func<User, bool> filter)
	    {
			const string getAllAlbumsUrl = "http://jsonplaceholder.typicode.com/users";

		    var urlData = await this.httpClient.GetStringAsync(getAllAlbumsUrl);

		    var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.User>>(urlData);

		    return Mapper.Map(collection).Where(filter.Invoke);
		}
    }
}

using Newtonsoft.Json;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleService.Dao
{
	public class AlbumDao : IAlbumDao
	{
		private readonly HttpClient httpClient;

		public AlbumDao()
		{
			this.httpClient = new HttpClient();
		}

		public async Task<Album> Get(int id)
		{
			string getAllAlbumsUrl = $"http://jsonplaceholder.typicode.com/albums/{id}";

			var urlData = await this.httpClient.GetStringAsync(getAllAlbumsUrl);

			var album = JsonConvert.DeserializeObject<InternalEntities.Album>(urlData);

			return Mapper.Map(album);
		}

		public async Task<IEnumerable<Album>> Get(Func<Album, bool> filter)
		{
			const string getAllAlbumsUrl = "http://jsonplaceholder.typicode.com/albums";

			var urlData = await this.httpClient.GetStringAsync(getAllAlbumsUrl);

			var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.Album>>(urlData);

			return Mapper.Map(collection).Where(filter.Invoke);
		}
	}
}
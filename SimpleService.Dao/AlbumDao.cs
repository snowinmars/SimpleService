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
	public class AlbumDao : IAlbumDao
	{
		private readonly HttpClient httpClient;

		public AlbumDao()
		{
			this.httpClient = new HttpClient();
		}

		public async Task<Album> Get(int id)
		{
			string getAlbumByIdUrl = string.Format(Config.Url.AlbumByIdFormat, id);

			var urlData = await this.httpClient.GetStringAsync(getAlbumByIdUrl);

			var album = JsonConvert.DeserializeObject<InternalEntities.Album>(urlData);

			return Mapper.Map(album);
		}

		public async Task<IEnumerable<Album>> Get(Func<Album, bool> filter)
		{
			string getAllAlbumsUrl = Config.Url.Albums;

			var urlData = await this.httpClient.GetStringAsync(getAllAlbumsUrl);

			var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.Album>>(urlData);

			return Mapper.Map(collection).Where(filter.Invoke);
		}
	}
}
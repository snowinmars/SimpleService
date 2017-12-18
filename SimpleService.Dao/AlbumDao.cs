using Newtonsoft.Json;
using SimpleService.Common;
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

		public async Task<Album> GetAsync(int id)
		{
			string getAlbumByIdUrl = string.Format(Config.Url.AlbumByIdFormat, id);

			var urlData = this.httpClient.GetStringAsync(getAlbumByIdUrl);

			var album = JsonConvert.DeserializeObject<InternalEntities.Album>(await urlData);

			return Mapper.Map(album);
		}

		public async Task<Page<Album>> GetAsync(Func<Album, bool> filter, PageInfo pageInfo)
		{
			string getAllAlbumsUrl = Config.Url.Albums;

			var urlData = this.httpClient.GetStringAsync(getAllAlbumsUrl);

			var collection = JsonConvert.DeserializeObject<IEnumerable<InternalEntities.Album>>(await urlData);

			var albums = Mapper.Map(collection).Where(filter.Invoke).ToList();

			return Page<Album>.Pagify(pageInfo, albums);
		}
	}
}
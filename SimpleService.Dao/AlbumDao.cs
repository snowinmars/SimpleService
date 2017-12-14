using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;

namespace SimpleService.Dao
{
	public class AlbumDao : IAlbumDao
	{
		private HttpClient httpClient;

		public AlbumDao()
		{
			this.httpClient = new HttpClient();
		}

		public Album Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Album> Get(Func<Album, bool> filter)
		{
			const string getAllAlbumsUrl = "http://jsonplaceholder.typicode.com/albums";
			
			return null;
		}
	}
}

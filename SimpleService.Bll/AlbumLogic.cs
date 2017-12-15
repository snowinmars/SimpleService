using SimpleService.Bll.Interfaces;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleService.Bll
{
	public class AlbumLogic : IAlbumLogic
	{
		private readonly IAlbumDao albumDao;

		public AlbumLogic(IAlbumDao albumDao)
		{
			this.albumDao = albumDao;
			this.DefaultFilter = album => true;
		}

		public Func<Album, bool> DefaultFilter { get; }

		public Task<Album> Get(int id)
		{
			return this.albumDao.Get(id);
		}

		public Task<IEnumerable<Album>> Get(Func<Album, bool> filter)
		{
			return this.albumDao.Get(filter);
		}
	}
}
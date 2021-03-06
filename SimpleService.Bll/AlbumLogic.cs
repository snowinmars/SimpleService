﻿using SimpleService.Bll.Interfaces;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;
using System;
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

		public Task<Album> GetAsync(int id)
		{
			return this.albumDao.GetAsync(id);
		}

		public Task<Page<Album>> GetAsync(Func<Album, bool> filter, PageInfo pageInfo)
		{
			return this.albumDao.GetAsync(filter, pageInfo);
		}
	}
}
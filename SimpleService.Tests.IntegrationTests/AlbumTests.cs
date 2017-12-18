using System;
using Ninject;
using NUnit.Framework;
using SimpleService.Bll.Interfaces;
using SimpleService.Entities;
using SimpleService.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleService.Tests.IntegrationTests
{
	public class AlbumTests
	{
		private readonly IAlbumLogic logic;
		private readonly PageInfo pageInfo;

		public AlbumTests()
		{
			var kernel = NinjectWebCommon.GetKernel();
			this.logic = kernel.Get<IAlbumLogic>();

			this.pageInfo = new PageInfo
			{
				PageNumber = 0,
				PageSize = int.MaxValue / 2,
			};
		}

		[Test]
		public async Task Album_GetByFilter_DefaultFilter()
		{
			var albums = await this.logic.GetAsync(this.logic.DefaultFilter, this.pageInfo);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 100, actual: albums.Result.Count());
			Assert.AreEqual(expected: 100, actual: albums.TotalItems);
			Assert.AreEqual(expected: 1, actual: albums.TotalPages);
		}

		[Test]
		public async Task Album_GetByFilter_DefaultFilter_Paging()
		{
			PageInfo pageInfo = new PageInfo
			{
				PageNumber = 2,
				PageSize = 10,
			};

			var albums = await this.logic.GetAsync(this.logic.DefaultFilter, pageInfo);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: pageInfo.PageSize, actual: albums.Result.Count());
			Assert.AreEqual(expected: 100, actual: albums.TotalItems);
			Assert.AreEqual(expected: 10, actual: albums.TotalPages);
		}

		[Test]
		public async Task Album_GetByFilter_TitleLength()
		{
			var albums = await this.logic.GetAsync(u => u.Title.Length < 21, this.pageInfo);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 17, actual: albums.Result.Count());
		}

		[Test]
		public async Task Album_GetByFilter_UserId()
		{
			var albums = await this.logic.GetAsync(u => u.UserId == 1, this.pageInfo);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 10, actual: albums.Result.Count());
		}

		[Test]
		[TestCaseSource("GetAlbumsByIdCollection")]
		public async Task Album_GetById(Album expectedAlbum)
		{
			var albums = await this.logic.GetAsync(expectedAlbum.Id);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: expectedAlbum, actual: albums);
		}

		private static IEnumerable<object> GetAlbumsByIdCollection()
		{
			yield return new Album
			{
				Id = 9,
				UserId = 1,
				Title = "saepe unde necessitatibus rem",
			};
			yield return new Album
			{
				Id = 67,
				UserId = 7,
				Title = "ad voluptas nostrum et nihil",
			};
		}
	}
}
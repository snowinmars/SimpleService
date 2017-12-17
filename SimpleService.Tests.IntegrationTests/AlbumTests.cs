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

		public AlbumTests()
		{
			var kernel = NinjectWebCommon.GetKernel();
			this.logic = kernel.Get<IAlbumLogic>();
		}

		[Test]
		public async Task Album_GetByFilter_DefaultFilter()
		{
			var albums = await this.logic.GetAsync(this.logic.DefaultFilter);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 100, actual: albums.Count());
		}

		[Test]
		public async Task Album_GetByFilter_TitleLength()
		{
			var albums = await this.logic.GetAsync(u => u.Title.Length < 21);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 17, actual: albums.Count());
		}

		[Test]
		public async Task Album_GetByFilter_UserId()
		{
			var albums = await this.logic.GetAsync(u => u.UserId == 1);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 10, actual: albums.Count());
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
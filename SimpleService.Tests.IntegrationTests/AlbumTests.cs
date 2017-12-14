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
		private IAlbumLogic logic;

		[Test]
		public async Task Album_GetByFilter_DefaultFilter()
		{
			var albums = await this.logic.Get(this.logic.DefaultFilter);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 100, actual: albums.Count());
		}

		[Test]
		public async Task Album_GetByFilter_TitleLength()
		{
			var albums = await this.logic.Get(u => u.Title.Length < 21);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 17, actual: albums.Count());
		}

		[Test]
		public async Task Album_GetByFilter_UserId()
		{
			var albums = await this.logic.Get(u => u.UserId == 1);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: 10, actual: albums.Count());
		}

		[Test]
		[TestCaseSource("GetByIdCollection")]
		public async Task Album_GetById(Album expectedAlbum)
		{
			var albums = await this.logic.Get(expectedAlbum.Id);

			Assert.IsNotNull(albums);

			Assert.AreEqual(expected: expectedAlbum, actual: albums);
		}

		[SetUp]
		public void MyTestInitialize()
		{
			var kernel = NinjectWebCommon.GetKernel();
			this.logic = kernel.Get<IAlbumLogic>();
		}

		private static IEnumerable<object> GetByIdCollection()
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
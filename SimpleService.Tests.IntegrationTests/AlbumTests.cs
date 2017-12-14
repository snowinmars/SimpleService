using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SimpleService.Bll.Interfaces;
using SimpleService.Entities;
using SimpleService.WebApi;

namespace SimpleService.Tests.IntegrationTests
{
    public class AlbumTests
    {
	    [SetUp]
	    public void MyTestInitialize()
	    {
		    var kernel = NinjectWebCommon.GetKernel();
		    this.logic = kernel.Get<IAlbumLogic>();
	    }

		private IAlbumLogic logic;

	    [Test]
	    public async Task GetByFilter_DefaultFilter()
	    {
		    var a = await this.logic.Get(this.logic.DefaultFilter);

			Assert.IsNotNull(a);

			Assert.AreEqual(expected: 100, actual: a.Count());
	    }

		[Test]
		[TestCaseSource("GetByIdCollection")]
		public async Task GetById(User expectedUser)
	    {
		    var a = await this.logic.Get(expectedUser.Id);

			Assert.IsNotNull(a);
	    }

		[Test]
	    public async Task GetByFilter_TitleLength()
	    {
		    var a = await this.logic.Get(u => u.Title.Length < 21);

		    Assert.IsNotNull(a);
	    }

	    [Test]
	    public async Task GetByFilter_UserId()
	    {
		    var a = await this.logic.Get(u => u.UserId == 1);

		    Assert.IsNotNull(a);
	    }

		private static IEnumerable<object> GetByIdCollection()
	    {
		    yield return new User
		    {
			    Id = 1,
			    Name = "Leanne Graham",
			    UserName = "Bret",
			    Email = "Sincere@april.biz",
			    Address = new Address
			    {
				    Street = "Kulas Light",
				    Suite = "Apt. 556",
				    City = new City
				    {
					    Name = "Gwenborough",
				    },
				    ZipCode = "92998-3874",
				    Geolocation = new Geolocation
				    {
					    Latitude = -37.3159,
					    Longitude = 81.1496,
				    }
			    },
			    Phone = "1-770-736-8031 x56442",
			    WebSite = "hildegard.org",
			    Company = new Company
			    {
				    Name = "Romaguera-Crona",
				    CatchPhrase = "Multi-layered client-server neural-net",
				    Bs = "harness real-time e-markets",
			    }
		    };

		    yield return new User
		    {
			    Id = 5,
			    Name = "Chelsey Dietrich",
			    UserName = "Kamren",
			    Email = "Lucio_Hettinger@annie.ca",
			    Address = new Address
			    {
				    Street = "Skiles Walks",
				    Suite = "Suite 351",
				    City = new City
				    {
					    Name = "Roscoeview",
				    },
				    ZipCode = "33263",
				    Geolocation = new Geolocation
				    {
					    Latitude = -31.8129,
					    Longitude = 62.5342,
				    }
			    },
			    Phone = "(254)954-1289",
			    WebSite = "demarco.info",
			    Company = new Company
			    {
				    Name = "Keebler LLC",
				    CatchPhrase = "User-centric fault-tolerant solution",
				    Bs = "revolutionize end-to-end systems",
			    }
		    };
		}

	}
}

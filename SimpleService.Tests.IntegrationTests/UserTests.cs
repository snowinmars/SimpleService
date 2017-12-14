using System.Collections.Generic;
using Ninject;
using NUnit.Framework;
using SimpleService.Bll.Interfaces;
using SimpleService.WebApi;
using System.Linq;
using System.Threading.Tasks;
using SimpleService.Entities;

namespace SimpleService.Tests.IntegrationTests
{
	public class UserTests
	{
		private IUserLogic logic;

		[Test]
		public async Task User_GetByFilter_AddressCityNameContains()
		{
			var users = await this.logic.Get(u => u.Address.City.Name.Contains(" "));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressGeolocationLatitude()
		{
			var users = await this.logic.Get(u => u.Address.Geolocation.Latitude < -30);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 6, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressGeolocationLongitude()
		{
			var users = await this.logic.Get(u => u.Address.Geolocation.Longitude > 60);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 3, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressStreet()
		{
			var users = await this.logic.Get(u => u.Address.Street.Split(' ').Any(s => s.Length < 5));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 3, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressSuiteContains()
		{
			var users = await this.logic.Get(u => u.Address.Suite.Contains("."));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 3, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressZipCodeDoesntContains()
		{
			var users = await this.logic.Get(u => !u.Address.ZipCode.Contains("-"));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_CompanyBsContains()
		{
			var users = await this.logic.Get(u => u.Company.Bs.Contains("-"));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 10, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_CompanyCatchPhraseContains()
		{
			var users = await this.logic.Get(u => u.Company.CatchPhrase.Contains("-"));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 7, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_CompanyNameContains()
		{
			var users = await this.logic.Get(u => u.Company.Name.Contains("LLC"));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_DefaultFilter()
		{
			var users = await this.logic.Get(this.logic.DefaultFilter);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 10, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_EmailContains()
		{
			var users = await this.logic.Get(u => u.Email.Contains("net"));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 1, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_PhoneStartWith()
		{
			var users = await this.logic.Get(u => u.Phone.StartsWith("("));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_UserNameLength()
		{
			var users = await this.logic.Get(u => u.UserName.Length < 5);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 1, actual: users.Count());
		}

		[Test]
		public async Task User_GetByFilter_WebSiteContains()
		{
			var users = await this.logic.Get(u => u.WebSite.Contains("info"));

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Count());
		}

		[SetUp]
		public void MyTestInitialize()
		{
			var kernel = NinjectWebCommon.GetKernel();
			this.logic = kernel.Get<IUserLogic>();
		}

		[Test]
		[TestCaseSource("GetByIdCollection")]
		public async Task User_GetById(User expectedUser)
		{
			var user = await this.logic.Get(expectedUser.Id);

			Assert.IsNotNull(user);

			Assert.AreEqual(expected: expectedUser, actual: user);
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
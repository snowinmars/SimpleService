using Ninject;
using NUnit.Framework;
using SimpleService.Bll.Interfaces;
using SimpleService.Entities;
using SimpleService.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleService.Tests.IntegrationTests
{
	public class UserTests
	{
		private readonly IUserLogic logic;
		private readonly PageInfo pageInfo;

		public UserTests()
		{
			var kernel = NinjectWebCommon.GetKernel();
			this.logic = kernel.Get<IUserLogic>();

			this.pageInfo = new PageInfo
			{
				PageNumber = 0,
				PageSize = Int32.MaxValue / 2,
			};
		}

		[Test]
		public async Task User_GetAlbumsById()
		{
			UserAndAlbumd expectedPair = UserTests.GetUserAndAlbum();

			var user = await this.logic.GetAsync(expectedPair.User.Id);

			Assert.IsNotNull(user);

			var albums = await this.logic.GetAlbumsAsync(user.Id, this.pageInfo);

			Assert.AreEqual(expected: expectedPair.User, actual: user);

			foreach (var pair in from album in albums.Result
								 from expectedAlbum in expectedPair.Albums
								 where album.Id == expectedAlbum.Id
								 select new
								 {
									 Album = album,
									 ExpectedAlbum = expectedAlbum,
								 })
			{
				Assert.AreEqual(expected: pair.ExpectedAlbum, actual: pair.Album);
			}
		}

		[Test]
		public async Task User_GetByFilter_AddressCityNameContains()
		{
			var users = await this.logic.GetAsync(u => u.Address.City.Name.Contains(" "), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressGeolocationLatitude()
		{
			var users = await this.logic.GetAsync(u => u.Address.Geolocation.Latitude < -30, this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 6, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressGeolocationLongitude()
		{
			var users = await this.logic.GetAsync(u => u.Address.Geolocation.Longitude > 60, this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 3, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressStreet()
		{
			var users = await this.logic.GetAsync(u => u.Address.Street.Split(' ').Any(s => s.Length < 5), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 3, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressSuiteContains()
		{
			var users = await this.logic.GetAsync(u => u.Address.Suite.Contains("."), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 3, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_AddressZipCodeDoesntContains()
		{
			var users = await this.logic.GetAsync(u => !u.Address.ZipCode.Contains("-"), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_CompanyBsContains()
		{
			var users = await this.logic.GetAsync(u => u.Company.Bs.Contains("-"), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 10, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_CompanyCatchPhraseContains()
		{
			var users = await this.logic.GetAsync(u => u.Company.CatchPhrase.Contains("-"), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 7, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_CompanyNameContains()
		{
			var users = await this.logic.GetAsync(u => u.Company.Name.Contains("LLC"), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_DefaultFilter()
		{
			var users = await this.logic.GetAsync(this.logic.DefaultFilter, this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 10, actual: users.Result.Count());
			Assert.AreEqual(expected: 10, actual: users.TotalItems);
			Assert.AreEqual(expected: 1, actual: users.TotalPages);
		}

		[Test]
		public async Task User_GetByFilter_DefaultFilter_Paging()
		{
			PageInfo pageInfo = new PageInfo
			{
				PageNumber = 2,
				PageSize = 2,
			};

			var users = await this.logic.GetAsync(this.logic.DefaultFilter, pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: pageInfo.PageSize, actual: users.Result.Count());
			Assert.AreEqual(expected: 10, actual: users.TotalItems);
			Assert.AreEqual(expected: 5, actual: users.TotalPages);
		}

		[Test]
		public async Task User_GetByFilter_EmailContains()
		{
			var users = await this.logic.GetAsync(u => u.Email.Contains("net"), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 1, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_PhoneStartWith()
		{
			var users = await this.logic.GetAsync(u => u.Phone.StartsWith("("), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_UserNameLength()
		{
			var users = await this.logic.GetAsync(u => u.UserName.Length < 5, this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 1, actual: users.Result.Count());
		}

		[Test]
		public async Task User_GetByFilter_WebSiteContains()
		{
			var users = await this.logic.GetAsync(u => u.WebSite.Contains("info"), this.pageInfo);

			Assert.IsNotNull(users);

			Assert.AreEqual(expected: 2, actual: users.Result.Count());
		}

		[Test]
		[TestCaseSource("GetUsersByIdCollection")]
		public async Task User_GetById(User expectedUser)
		{
			var user = await this.logic.GetAsync(expectedUser.Id);

			Assert.IsNotNull(user);

			Assert.AreEqual(expected: expectedUser, actual: user);
		}

		private static UserAndAlbumd GetUserAndAlbum()
		{
			var expectedPair = new UserAndAlbumd
			{
				User = new User
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
				}
			};

			expectedPair.Albums.Add(new Album
			{
				Id = 1,
				UserId = 1,
				Title = "quidem molestiae enim",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 2,
				UserId = 1,
				Title = "sunt qui excepturi placeat culpa",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 3,
				UserId = 1,
				Title = "omnis laborum odio",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 4,
				UserId = 1,
				Title = "non esse culpa molestiae omnis sed optio",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 5,
				UserId = 1,
				Title = "eaque aut omnis a",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 6,
				UserId = 1,
				Title = "natus impedit quibusdam illo est",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 7,
				UserId = 1,
				Title = "quibusdam autem aliquid et et quia",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 8,
				UserId = 1,
				Title = "qui fuga est a eum",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 9,
				UserId = 1,
				Title = "saepe unde necessitatibus rem",
			});
			expectedPair.Albums.Add(new Album
			{
				Id = 10,
				UserId = 1,
				Title = "distinctio laborum qui",
			});
			return expectedPair;
		}

		private static IEnumerable<object> GetUsersByIdCollection()
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

		private class UserAndAlbumd
		{
			public UserAndAlbumd()
			{
				this.Albums = new List<Album>();
			}

			public IList<Album> Albums { get; private set; }
			public User User { get; set; }
		}
	}
}
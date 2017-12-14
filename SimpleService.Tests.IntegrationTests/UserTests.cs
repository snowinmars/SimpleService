using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NUnit.Framework;
using SimpleService.Bll.Interfaces;
using SimpleService.WebApi;

namespace SimpleService.Tests.IntegrationTests
{
	public class UserTests
	{
		[SetUp]
		public void MyTestInitialize()
		{
			var kernel = NinjectWebCommon.GetKernel();
			this.logic = kernel.Get<IUserLogic>();
		}

		private IUserLogic logic;

		[Test]
		public async Task GetByFilter_UserNameLength()
		{
			var a = await this.logic.Get(u => u.UserName.Length < 5);

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_CompanyNameContains()
		{
			var a = await this.logic.Get(u => u.Company.Name.Contains("LLC"));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_CompanyCatchPhraseContains()
		{
			var a = await this.logic.Get(u => u.Company.CatchPhrase.Contains("-"));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_CompanyBsContains()
		{
			var a = await this.logic.Get(u => u.Company.Bs.Contains("-"));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_AddressStreet()
		{
			var a = await this.logic.Get(u => u.Address.Street.Split(' ').Any(s => s.Length < 5));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_AddressSuiteContains()
		{
			var a = await this.logic.Get(u => u.Address.Suite.Contains("."));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_AddressZipCodeDoesntContains()
		{
			var a = await this.logic.Get(u => !u.Address.ZipCode.Contains("-"));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_AddressGeolocationLongitude()
		{
			var a = await this.logic.Get(u => u.Address.Geolocation.Longitude > 60);

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_AddressGeolocationLatitude()
		{
			var a = await this.logic.Get(u => u.Address.Geolocation.Latitude < -30);

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_AddressCityNameContains()
		{
			var a = await this.logic.Get(u => u.Address.City.Name.Contains(" "));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_EmailContains()
		{
			var a = await this.logic.Get(u => u.Email.Contains("net"));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_PhoneStartWith()
		{
			var a = await this.logic.Get(u => u.Phone.StartsWith("("));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_WebSiteContains()
		{
			var a = await this.logic.Get(u => u.WebSite.Contains("info"));

			Assert.IsNotNull(a);
		}

		[Test]
		public async Task GetByFilter_DefaultFilter()
		{
			var a = await this.logic.Get(this.logic.DefaultFilter);

			Assert.IsNotNull(a);
		}
	}
}

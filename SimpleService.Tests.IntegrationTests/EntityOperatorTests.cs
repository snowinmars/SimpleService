using NUnit.Framework;
using SandS.Algorithm.Library.GeneratorNamespace;
using SimpleService.Entities;
using System;

namespace SimpleService.Tests.IntegrationTests
{
	public class EntityOperatorTests
	{
		private readonly Random randomGenerator;
		private readonly TextGenerator textGenerator;

		public EntityOperatorTests()
		{
			this.textGenerator = new TextGenerator();
			this.randomGenerator = new Random();
		}

		[Test]
		public void Address_Equals()
		{
			this.AssertEquals(this.GetNewAddress, a => a.DeepClone());
			this.AssertHashCode(this.GetNewAddress, a => a.DeepClone());
		}

		[Test]
		public void Album_Equals()
		{
			this.AssertEquals(this.GetNewAlbum, a => a.DeepClone());
			this.AssertHashCode(this.GetNewAlbum, a => a.DeepClone());
		}

		[Test]
		public void City_Equals()
		{
			this.AssertEquals(this.GetNewCity, c => c.DeepClone());
			this.AssertHashCode(this.GetNewCity, c => c.DeepClone());
		}

		[Test]
		public void Company_Equals()
		{
			this.AssertEquals(this.GetNewCompany, c => c.DeepClone());
			this.AssertHashCode(this.GetNewCompany, c => c.DeepClone());
		}

		[Test]
		public void Geolocation_Equals()
		{
			this.AssertEquals(this.GetNewGeolocation, g => g.DeepClone());
			this.AssertHashCode(this.GetNewGeolocation, g => g.DeepClone());
		}

		[Test]
		public void User_Equals()
		{
			this.AssertEquals(this.GetNewUser, u => u.DeepClone());
			this.AssertHashCode(this.GetNewUser, u => u.DeepClone());
		}

		protected void AssertHashCode<T>(Func<T> generate, Func<T, T> copy)
			where T : class
		{
			T lhs = generate.Invoke();
			T rhs = generate.Invoke();

			Assert.IsFalse(lhs.GetHashCode() == rhs.GetHashCode());

			rhs = copy.Invoke(lhs);

			Assert.IsTrue(lhs.GetHashCode() == rhs.GetHashCode());
		}

		protected void AssertEquals<T>(Func<T> generate, Func<T, T> copy)
			where T : class
		{
			T lhs = generate.Invoke();
			T rhs = null;

			Assert.IsFalse(lhs.Equals(rhs));

			rhs = generate.Invoke();

			Assert.IsFalse(lhs.Equals(rhs));

			rhs = copy.Invoke(lhs);

			Assert.IsTrue(lhs.Equals(rhs));

			object smth = new object();

			Assert.IsFalse(lhs.Equals(smth));
			Assert.IsFalse(rhs.Equals(smth));
			Assert.IsFalse(smth.Equals(lhs));
			Assert.IsFalse(smth.Equals(rhs));
		}

		private Address GetNewAddress()
		{
			return new Address
			{
				City = this.GetNewCity(),
				Geolocation = this.GetNewGeolocation(),
				Suite = this.textGenerator.GetNewWord(4, 15, true),
				ZipCode = this.textGenerator.GetNewWord(4, 15, true),
				Street = this.textGenerator.GetNewWord(4, 15, true),
			};
		}

		private Album GetNewAlbum()
		{
			return new Album
			{
				Title = string.Join(" ", this.textGenerator.GetWords(15)),
				Id = this.randomGenerator.Next(1, 100),
				UserId = this.randomGenerator.Next(1, 10),
			};
		}

		private City GetNewCity()
		{
			return new City
			{
				Name = this.textGenerator.GetNewWord(4, 15, true),
			};
		}

		private Company GetNewCompany()
		{
			return new Company
			{
				Name = this.textGenerator.GetNewWord(4, 15, true),
				CatchPhrase = string.Join(" ", this.textGenerator.GetWords(15)),
				Bs = string.Join(" ", this.textGenerator.GetWords(15)),
			};
		}

		private Geolocation GetNewGeolocation()
		{
			return new Geolocation
			{
				Longitude = this.randomGenerator.NextDouble(-50, 50),
				Latitude = this.randomGenerator.NextDouble(-50, 50),
			};
		}

		private User GetNewUser()
		{
			return new User
			{
				Name = this.textGenerator.GetNewWord(4, 15, true),
				UserName = this.textGenerator.GetNewWord(4, 15, true),
				Id = this.randomGenerator.Next(1, 10),
				WebSite = $"{this.textGenerator.GetNewWord(4, 15, true)}.com",
				Email = $"{this.textGenerator.GetNewWord(4, 15, true)}@{this.textGenerator.GetNewWord(4, 15, true)}.net",
				Phone = this.textGenerator.GetNewWord(4, 15, true),
				Company = this.GetNewCompany(),
				Address = this.GetNewAddress(),
			};
		}
	}
}
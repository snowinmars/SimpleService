using SimpleService.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SimpleService.Dao
{
	internal static class Mapper
	{
		internal static IEnumerable<Album> Map(IEnumerable<InternalEntities.Album> internalAlbums)
		{
			return internalAlbums.Select(Mapper.Map);
		}

		internal static IEnumerable<User> Map(IEnumerable<InternalEntities.User> internalUsers)
		{
			return internalUsers.Select(Mapper.Map);
		}

		internal static Album Map(InternalEntities.Album internalAlbum)
		{
			return new Album
			{
				Id = internalAlbum.Id,
				UserId = internalAlbum.UserId,
				Title = internalAlbum.Title,
			};
		}

		internal static User Map(InternalEntities.User internalUser)
		{
			var address = Mapper.Map(internalUser.Address);
			var company = Mapper.Map(internalUser.Company);

			return new User
			{
				Id = internalUser.Id,
				Email = internalUser.Email,
				Name = internalUser.Name,
				Phone = internalUser.Phone,
				UserName = internalUser.UserName,
				WebSite = internalUser.WebSite,
				Address = address,
				Company = company,
			};
		}

		internal static Company Map(InternalEntities.Company internalCompany)
		{
			return new Company
			{
				Name = internalCompany.Name,
				CatchPhrase = internalCompany.CatchPhrase,
				Bs = internalCompany.Bs,
			};
		}

		internal static Geolocation Map(InternalEntities.Geolocation internalGeolocation)
		{
			return new Geolocation
			{
				Latitude = internalGeolocation.Lat,
				Longitude = internalGeolocation.Lng,
			};
		}

		internal static Address Map(InternalEntities.Address internalAddress)
		{
			var city = new City
			{
				Name = internalAddress.City,
			};

			var geolocation = Mapper.Map(internalAddress.Geo);

			return new Address
			{
				Street = internalAddress.Street,
				Suite = internalAddress.Suite,
				ZipCode = internalAddress.ZipCode,
				City = city,
				Geolocation = geolocation,
			};
		}
	}
}
namespace SimpleService.Dao.InternalEntities
{
	internal class Address
	{
		public Address()
		{
			this.Geo = new InternalEntities.Geolocation();
		}

		public string City { get; set; }
		public InternalEntities.Geolocation Geo { get; set; }
		public string Street { get; set; }
		public string Suite { get; set; }
		public string ZipCode { get; set; }
	}
}
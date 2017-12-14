namespace SimpleService.Dao.InternalEntities
{
	internal class Address
	{
		public string City { get; set; }
		public InternalEntities.Geolocation Geolocation { get; set; }
		public string Street { get; set; }
		public string Suite { get; set; }
		public string ZipCode { get; set; }
	}
}
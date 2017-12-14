namespace SimpleService.Entities
{
	public class Address
	{
		public string Street { get; set; }

		public string Suite { get; set; }

		public City City { get; set; }

		public string ZipCode { get; set; }

		public Geolocation Geolocation { get; set; }
	}
}
namespace SimpleService.Entities
{
	public class Address
	{
		public City City { get; set; }
		public Geolocation Geolocation { get; set; }
		public string Street { get; set; }
		public string Suite { get; set; }
		public string ZipCode { get; set; }
	}
}
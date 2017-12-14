using System;

namespace SimpleService.Entities
{
	public class User
	{
		public Address Address { get; set; }
		public int Age { get; set; }
		public Company Company { get; set; }
		public string Email { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string UserName { get; set; }
		public Uri WebSite { get; set; }
	}
}
using System;

namespace SimpleService.Dao.InternalEntities
{
	internal class User
	{
		public User()
		{
			this.Address = new InternalEntities.Address();
			this.Company = new InternalEntities.Company();
		}

		public InternalEntities.Address Address { get; set; }
		public InternalEntities.Company Company { get; set; }
		public string Email { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string UserName { get; set; }
		public string WebSite { get; set; }
	}
}
using System;
using System.Text.RegularExpressions;

namespace SimpleService.Entities
{
	public class User
	{
		private string webSite;
		public Address Address { get; set; }
		public Company Company { get; set; }
		public string Email { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string UserName { get; set; }

		public string WebSite
		{
			get { return this.webSite; }
			set
			{
				const string urlRegex = @"(https?:\/\/(www\.)?)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,4}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

				if (!Regex.IsMatch(value, urlRegex, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
				{
					throw new InvalidOperationException($"{value} is not url");
				}

				this.webSite = value;
			}
		}
	}
}
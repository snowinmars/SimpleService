using System;
using System.Text.RegularExpressions;

namespace SimpleService.Entities
{
	public class User
	{
		public User()
		{
			this.Address = new Address();
			this.Company = new Company();
		}

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

		public override bool Equals(object obj)
		{
			User user = obj as User;

			return !object.ReferenceEquals(user, null) && this.Equals(user);
		}

		protected bool Equals(User other)
		{
			return string.Equals(this.webSite, other.webSite) &&
				Equals(this.Address, other.Address) &&
				Equals(this.Company, other.Company) &&
				string.Equals(this.Email, other.Email) &&
				this.Id == other.Id &&
				string.Equals(this.Name, other.Name) &&
				string.Equals(this.Phone, other.Phone) &&
				string.Equals(this.UserName, other.UserName);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (object.ReferenceEquals(this.webSite, null) ? this.webSite.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.Address, null) ? this.Address.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.Company, null) ? this.Company.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.Email, null) ? this.Email.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ this.Id;
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.Name, null) ? this.Name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.Phone, null) ? this.Phone.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.UserName, null) ? this.UserName.GetHashCode() : 0);
				return hashCode;
			}
		}

		public static bool operator ==(User lhs, User rhs)
		{
			if (object.ReferenceEquals(lhs, null) && object.ReferenceEquals(rhs, null))
			{
				return true;
			}

			if (object.ReferenceEquals(lhs, null) ||
				object.ReferenceEquals(rhs, null))
			{
				return false;
			}

			return lhs.Equals(rhs);
		}

		public static bool operator !=(User lhs, User rhs)
		{
			return !(lhs == rhs);
		}
	}
}
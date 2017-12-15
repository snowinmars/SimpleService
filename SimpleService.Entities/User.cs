using System;
using System.Text.RegularExpressions;
using SimpleService.Common;

namespace SimpleService.Entities
{
	public class User : IDeepClonable<User>
	{
		private string webSite;
		private string email;

		public User()
		{
			this.Address = new Address();
			this.Company = new Company();
		}

		public Address Address { get; set; }
		public Company Company { get; set; }

		public string Email
		{
			get { return this.email; }
			set
			{
				const string emailRegex = Config.EmailRegex;

				if (!Regex.IsMatch(value, emailRegex, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
				{
					throw new InvalidOperationException($"{value} is not email");
				}

				this.email = value;
			}
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string UserName { get; set; }

		public string WebSite
		{
			get { return this.webSite; }
			set
			{
				const string urlRegex = Config.UrlRegex;

				if (!Regex.IsMatch(value, urlRegex, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
				{
					throw new InvalidOperationException($"{value} is not url");
				}

				this.webSite = value;
			}
		}

		public User DeepClone()
		{
			return new User
			{
				Email = this.Email,
				Id = this.Id,
				Name = this.Name,
				UserName = this.UserName,
				Phone = this.Phone,
				WebSite = this.WebSite,
				Company = this.Company.DeepClone(),
				Address = this.Address.DeepClone(),
			};
		}

		#region Equals

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(this, null) && // this could be true, take a look at call and callvirt codes
				object.ReferenceEquals(obj, null))
			{
				return true;
			}

			if (object.ReferenceEquals(this, null) ||
				object.ReferenceEquals(obj, null))
			{
				return false;
			}

			User user = obj as User;

			return !object.ReferenceEquals(user, null) && this.Equals(user);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (!object.ReferenceEquals(this.webSite, null) ? this.webSite.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Address, null) ? this.Address.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Company, null) ? this.Company.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Email, null) ? this.Email.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ this.Id;
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Name, null) ? this.Name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Phone, null) ? this.Phone.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.UserName, null) ? this.UserName.GetHashCode() : 0);
				return hashCode;
			}
		}

		protected bool Equals(User other)
		{
			return string.Equals(this.webSite, other.webSite) &&
				object.Equals(this.Address, other.Address) &&
				object.Equals(this.Company, other.Company) &&
				string.Equals(this.Email, other.Email) &&
				this.Id == other.Id &&
				string.Equals(this.Name, other.Name) &&
				string.Equals(this.Phone, other.Phone) &&
				string.Equals(this.UserName, other.UserName);
		}

		#endregion Equals
	}
}
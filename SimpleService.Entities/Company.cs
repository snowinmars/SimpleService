namespace SimpleService.Entities
{
	public class Company
	{
		public string Bs { get; set; }
		public string CatchPhrase { get; set; }
		public string Name { get; set; }

		public override bool Equals(object obj)
		{
			Company company = obj as Company;

			return !object.ReferenceEquals(company, null) && this.Equals(company);
		}

		protected bool Equals(Company other)
		{
			return string.Equals(this.Bs, other.Bs) &&
				string.Equals(this.CatchPhrase, other.CatchPhrase) &&
				string.Equals(this.Name, other.Name);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (object.ReferenceEquals(this.Bs, null) ? this.Bs.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.CatchPhrase, null) ? this.CatchPhrase.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.Name, null) ? this.Name.GetHashCode() : 0);
				return hashCode;
			}
		}

		public static bool operator ==(Company lhs, Company rhs)
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

		public static bool operator !=(Company lhs, Company rhs)
		{
			return !(lhs == rhs);
		}
	}
}
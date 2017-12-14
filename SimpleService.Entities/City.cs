namespace SimpleService.Entities
{
	public class City
	{
		public string Name { get; set; }

		public override bool Equals(object obj)
		{
			City city = obj as City;

			return !object.ReferenceEquals(city, null) && this.Equals(city);
		}

		protected bool Equals(City other)
		{
			return string.Equals(this.Name, other.Name);
		}

		public override int GetHashCode()
		{
			return (object.ReferenceEquals(this.Name, null) ? this.Name.GetHashCode() : 0);
		}

		public static bool operator ==(City lhs, City rhs)
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

		public static bool operator !=(City lhs, City rhs)
		{
			return !(lhs == rhs);
		}
	}
}
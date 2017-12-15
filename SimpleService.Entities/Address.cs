namespace SimpleService.Entities
{
	public class Address : IDeepClonable<Address>
	{
		public Address()
		{
			this.City = new City();
			this.Geolocation = new Geolocation();
		}

		public City City { get; set; }
		public Geolocation Geolocation { get; set; }
		public string Street { get; set; }
		public string Suite { get; set; }
		public string ZipCode { get; set; }

		public Address DeepClone()
		{
			return new Address
			{
				Street = this.Street,
				Suite = this.Suite,
				ZipCode = this.ZipCode,
				City = this.City.DeepClone(),
				Geolocation = this.Geolocation.DeepClone(),
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

			Address address = obj as Address;

			return !object.ReferenceEquals(address, null) && this.Equals(address);
		}

		protected bool Equals(Address other)
		{
			return Equals(this.City, other.City) &&
				Equals(this.Geolocation, other.Geolocation) &&
				string.Equals(this.Street, other.Street) &&
				string.Equals(this.Suite, other.Suite) &&
				string.Equals(this.ZipCode, other.ZipCode);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (!object.ReferenceEquals(this.City, null) ? this.City.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Geolocation, null) ? this.Geolocation.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Street, null) ? this.Street.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Suite, null) ? this.Suite.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.ZipCode, null) ? this.ZipCode.GetHashCode() : 0);
				return hashCode;
			}
		}

		#endregion Equals
	}
}
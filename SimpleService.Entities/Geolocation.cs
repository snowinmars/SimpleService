namespace SimpleService.Entities
{
	public class Geolocation
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public override bool Equals(object obj)
		{
			Geolocation geolocation = obj as Geolocation;

			return !object.ReferenceEquals(geolocation, null) && this.Equals(geolocation);
		}

		protected bool Equals(Geolocation other)
		{
			return this.Latitude.Equals(other.Latitude) &&
				this.Longitude.Equals(other.Longitude);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (this.Latitude.GetHashCode() * 397) ^ this.Longitude.GetHashCode();
			}
		}

		public static bool operator ==(Geolocation lhs, Geolocation rhs)
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

		public static bool operator !=(Geolocation lhs, Geolocation rhs)
		{
			return !(lhs == rhs);
		}
	}
}
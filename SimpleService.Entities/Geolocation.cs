namespace SimpleService.Entities
{
	public class Geolocation : IDeepClonable<Geolocation>
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public Geolocation DeepClone()
		{
			return new Geolocation
			{
				Longitude = this.Longitude,
				Latitude = this.Latitude,
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

		#endregion Equals
	}
}
namespace SimpleService.Entities
{
	public class City : IDeepClonable<City>
	{
		public string Name { get; set; }

		public City DeepClone()
		{
			return new City
			{
				Name = this.Name,
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

			City city = obj as City;

			return !object.ReferenceEquals(city, null) && this.Equals(city);
		}

		protected bool Equals(City other)
		{
			return string.Equals(this.Name, other.Name);
		}

		public override int GetHashCode()
		{
			return (!object.ReferenceEquals(this.Name, null) ? this.Name.GetHashCode() : 0);
		}

		#endregion Equals
	}
}
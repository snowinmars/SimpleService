namespace SimpleService.Entities
{
	public class Company : IDeepClonable<Company>
	{
		public string Bs { get; set; }
		public string CatchPhrase { get; set; }
		public string Name { get; set; }

		public Company DeepClone()
		{
			return new Company
			{
				Name = this.Name,
				CatchPhrase = this.CatchPhrase,
				Bs = this.Bs,
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

			Company company = obj as Company;

			return !object.ReferenceEquals(company, null) && this.Equals(company);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (!object.ReferenceEquals(this.Bs, null) ? this.Bs.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.CatchPhrase, null) ? this.CatchPhrase.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Name, null) ? this.Name.GetHashCode() : 0);
				return hashCode;
			}
		}

		protected bool Equals(Company other)
		{
			return string.Equals(this.Bs, other.Bs) &&
				string.Equals(this.CatchPhrase, other.CatchPhrase) &&
				string.Equals(this.Name, other.Name);
		}

		#endregion Equals
	}
}
namespace SimpleService.Entities
{
	public class Album : IDeepClonable<Album>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int UserId { get; set; }

		public Album DeepClone()
		{
			return new Album
			{
				Id = this.Id,
				UserId = this.UserId,
				Title = this.Title,
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

			Album album = obj as Album;

			return !object.ReferenceEquals(album, null) && this.Equals(album);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = this.Id;
				hashCode = (hashCode * 397) ^ (!object.ReferenceEquals(this.Title, null) ? this.Title.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ this.UserId;
				return hashCode;
			}
		}

		protected bool Equals(Album other)
		{
			return this.Id == other.Id &&
				string.Equals(this.Title, other.Title) &&
				this.UserId == other.UserId;
		}

		#endregion Equals
	}
}
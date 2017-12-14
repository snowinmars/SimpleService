namespace SimpleService.Entities
{
	public class Album
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int UserId { get; set; }

		public override bool Equals(object obj)
		{
			Album album = obj as Album;

			return !object.ReferenceEquals(album, null) && this.Equals(album);
		}

		protected bool Equals(Album other)
		{
			return this.Id == other.Id &&
				string.Equals(this.Title, other.Title) &&
				this.UserId == other.UserId;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = this.Id;
				hashCode = (hashCode * 397) ^ (object.ReferenceEquals(this.Title, null) ? this.Title.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ this.UserId;
				return hashCode;
			}
		}

		public static bool operator ==(Album lhs, Album rhs)
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

		public static bool operator !=(Album lhs, Album rhs)
		{
			return !(lhs == rhs);
		}
	}
}
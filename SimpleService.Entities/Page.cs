using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService.Entities
{
	public class Page<T>
	{
		public IEnumerable<T> Result { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int TotalPages
		{
			get
			{
				if (this.PageSize == 0)
				{
					return int.MaxValue / 2;
				}

				return (int) Math.Ceiling((decimal) this.TotalItems / this.PageSize);
			}
		}
		
		public Page() : this(new PageInfo())
		{
		}

		public Page(PageInfo pageInfo) : this(pageInfo, new List<T>(), 0)
		{
		}

		public Page(PageInfo pageInfo, IEnumerable<T> collection, int totalItems)
		{
			this.PageSize = pageInfo.PageSize;
			this.PageNumber = pageInfo.PageNumber;

			this.Result = collection;
			this.TotalItems = totalItems;
		}

		public static Page<T> Pagify(PageInfo pageInfo, ICollection<T> collection)
		{
			var page = collection.Page(pageInfo).ToList();

			return new Page<T>(pageInfo, page, collection.Count);
		}
	}
}

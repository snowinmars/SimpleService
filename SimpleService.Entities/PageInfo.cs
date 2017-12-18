using System.Collections.Generic;
using System.Linq;
using SimpleService.Common;

namespace SimpleService.Entities
{
	public static class PageInfoExtension
	{
		public static IEnumerable<T> Page<T>(this IEnumerable<T> collection, PageInfo pageInfo)
		{
			return collection.Skip(pageInfo.PageNumber * pageInfo.PageSize).Take(pageInfo.PageSize);
		}
	}

	public class PageInfo
	{
		public PageInfo() : this(0, Config.DefaultPageSize)
		{
		}

		public PageInfo(int pageNumebr, int pageSize)
		{
			this.PageNumber = pageNumebr;
			this.PageSize = pageSize;
		}

		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
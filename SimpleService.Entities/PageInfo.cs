using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleService.Entities
{
	public class PageInfo
	{
		public PageInfo() : this(0, 10)
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

	public static class PageInfoExtension
	{
		public static IEnumerable<T> Page<T>(this IEnumerable<T> collection, PageInfo pageInfo)
		{
			return collection.Skip(pageInfo.PageNumber * pageInfo.PageSize).Take(pageInfo.PageSize);
		}
	}
}
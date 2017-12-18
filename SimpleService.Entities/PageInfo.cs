using System;
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
		private int pageNumber;
		private int pageSize;

		public PageInfo() : this(0, Config.DefaultPageSize)
		{
		}

		public PageInfo(int pageNumebr, int pageSize)
		{
			this.PageNumber = pageNumebr;
			this.PageSize = pageSize;
		}

		public int PageNumber
		{
			get { return this.pageNumber; }

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException($"Page number can't be less then zero. Now it equals to {value}");
				}

				this.pageNumber = value;
			}
		}

		public int PageSize
		{
			get { return this.pageSize; }

			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException($"Page size can't be less then zero and can't be equal to zero. Now it equals to {value}");
				}

				this.pageSize = value;
			}
		}
	}
}
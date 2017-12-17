using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using YAXLib;
using Formatting = Newtonsoft.Json.Formatting;

namespace SimpleService.WebApi.Controllers
{
	[DefaultActionFilter]
	public class BaseController : ApiController
	{
		public ContentType contentType;

		protected IEnumerable<string> JsonString<T>(IEnumerable<T> collection)
		{
			return collection.Select(this.JsonString).ToList();
		}

		protected string JsonString<T>(T item)
		{
			return JsonConvert.SerializeObject(item, Formatting.Indented);
		}

		protected string Serialize<T>(IEnumerable<T> items)
			where T : class
		{
			ReturnCollection<T> c = new ReturnCollection<T>
			{
				Data = items,
			};

			switch (this.contentType)
			{
				case ContentType.None:
					throw new InvalidOperationException();

				case ContentType.Json:
					return this.JsonString(c);

				case ContentType.Xml:
					return this.XmlString(c);

				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		protected string Serialize<T>(T item)
			where T : class
		{
			switch (this.contentType)
			{
				case ContentType.None:
					throw new InvalidOperationException();

				case ContentType.Json:
					return this.JsonString(item);

				case ContentType.Xml:
					return this.XmlString(item);

				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		protected IEnumerable<string> XmlString<T>(IEnumerable<T> collection)
		{
			return collection.Select(this.XmlString).ToList();
		}

		protected string XmlString<T>(T item)
		{
			YAXSerializer serializer = new YAXSerializer(typeof(T));

			return serializer.Serialize(item);
		}
	}
}
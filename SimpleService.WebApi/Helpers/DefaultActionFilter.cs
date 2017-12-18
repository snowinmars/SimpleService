using SimpleService.WebApi.Controllers;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SimpleService.WebApi
{
	public class DefaultActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			ContentType contentType = DefaultActionFilter.GetContentType(actionContext);

			if (actionContext.ControllerContext.Controller is BaseController baseController)
			{
				baseController.ContentType = contentType;
			}
		}

		private static ContentType GetContentType(HttpActionContext actionContext)
		{
			ContentType contentType;

			if (actionContext.Request.Headers.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/xml")))
			{
				contentType = ContentType.Xml;
			}
			else
			{
				if (actionContext.Request.Content.Headers.ContentType != null &&
					actionContext.Request.Content.Headers.ContentType.MediaType == "application/xml")
				{
					contentType = ContentType.Xml;
				}
				else
				{
					contentType = ContentType.Json;
				}
			}

			return contentType;
		}
	}
}
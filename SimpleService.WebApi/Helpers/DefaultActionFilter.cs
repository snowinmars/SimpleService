using System;
using SimpleService.WebApi.Controllers;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SimpleService.WebApi
{
	public class DefaultActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			base.OnActionExecuted(actionExecutedContext);

			ContentType contentType = ContentType.None;

			if (actionExecutedContext.ActionContext.ControllerContext.Controller is BaseController baseController)
			{
				contentType = baseController.ContentType;
			}

			string headerContentType;

			switch (contentType)
			{
				case ContentType.None:
				case ContentType.Json:
					headerContentType = "application/json";
					break;
				case ContentType.Xml:
					headerContentType = "application/xml";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			actionExecutedContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue(headerContentType);
		}

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			base.OnActionExecuting(actionContext);

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
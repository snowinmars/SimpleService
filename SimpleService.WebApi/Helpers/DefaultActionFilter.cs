using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SimpleService.WebApi.Controllers;

namespace SimpleService.WebApi
{
	public class DefaultActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
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

			if (actionContext.ControllerContext.Controller is BaseController baseController)
			{
				baseController.contentType = contentType;
			}
		}
	}
}
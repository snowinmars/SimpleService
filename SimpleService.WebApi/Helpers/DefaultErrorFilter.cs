using System.Net;
using System.Web.Http.Filters;

namespace SimpleService.WebApi
{
	public class DefaultErrorFilter : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			base.OnException(actionExecutedContext);

			actionExecutedContext.Response.StatusCode = HttpStatusCode.InternalServerError;
		}
	}
}
using SimpleService.Bll.Interfaces;
using SimpleService.Entities;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleService.WebApi.Controllers
{
	[RoutePrefix("api/v1/users")]
	public class UsersController : BaseController
	{
		private readonly IUserLogic logic;

		public UsersController(IUserLogic logic)
		{
			this.logic = logic;
		}

		/// <summary>
		/// GET: api/Users/5/Albums
		/// Return albums that belongs to the user
		/// Return empty collection if there are no users
		/// On any other error returns 500
		/// </summary>
		/// 
		/// <param name="userId">
		/// Positive id
		/// </param>
		/// 
		/// <param name="pageInfo">
		/// Allow to choose the pageNumber and the pageSize for the request. 
		/// By default pageSize equals to 10 and pageNumber - to 0
		/// </param>
		/// 
		/// <returns>
		/// Json or Xml string (based on accept headers)
		/// The string contains PageNumber, PageSize, TotalItems, TotalPages and the Result fields
		/// </returns>
		[HttpGet]
		[Route("{userId}/albums")]
		public async Task<string> Albums(int userId, [FromUri]PageInfo pageInfo)
		{
			Page<Album> albums;

			try
			{
				albums = await this.logic.GetAlbumsAsync(userId, pageInfo);
			}
			catch (HttpRequestException)
			{
				albums = new Page<Album>();
			}
			catch
			{
				throw new HttpResponseException(this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal server error"));
			}

			return this.Serialize(albums);
		}

		/// <summary>
		/// GET: api/Users
		/// Return empty collection if there are no users
		/// On any other error returns 500
		/// </summary>
		/// 
		/// <param name="pageInfo">
		/// Allow to choose the pageNumber and the pageSize for the request. 
		/// By default pageSize equals to 10 and pageNumber - to 0
		/// </param>
		/// 
		/// <returns>
		/// Json or Xml string (based on accept headers)
		/// The string contains PageNumber, PageSize, TotalItems, TotalPages and the Result fields
		/// </returns>
		[HttpGet]
		public async Task<string> Get([FromUri]PageInfo pageInfo)
		{
			Page<User> users;

			try
			{
				users = await this.logic.GetAsync(this.logic.DefaultFilter, pageInfo);
			}
			catch (HttpRequestException)
			{
				users = new Page<User>();
			}
			catch
			{
				throw new HttpResponseException(this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal server error"));
			}

			return this.Serialize(users);
		}

		/// <summary>
		/// GET: api/Users/5
		/// If there's no user with given id, returns 404
		/// On any other error returns 500
		/// </summary>
		/// 
		/// <param name="id">
		/// Positive id
		/// </param>
		/// 
		/// <returns>
		/// Json or Xml string (based on accept headers)
		/// </returns>
		[HttpGet]
		public async Task<string> Get(int id)
		{
			User user;

			try
			{
				user = await this.logic.GetAsync(id);
			}
			catch (HttpRequestException)
			{
				throw new HttpResponseException(this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing found"));
			}
			catch
			{
				throw new HttpResponseException(this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal server error"));
			}

			return this.Serialize(user);
		}
	}
}
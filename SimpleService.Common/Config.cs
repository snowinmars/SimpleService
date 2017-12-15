using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService.Common
{
    public static class Config
    {
	    public const string UrlRegex = @"(https?:\/\/(www\.)?)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,4}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

	    public static class Url
	    {
		    public static string AlbumByIdFormat = "http://jsonplaceholder.typicode.com/albums/{0}";

		    public static string Albums = "http://jsonplaceholder.typicode.com/albums";

		    public static string UserByIdFormat = "http://jsonplaceholder.typicode.com/users/{0}";

		    public static string Users = "http://jsonplaceholder.typicode.com/users";

		    public static string AlbumByUserIdFormat = "http://jsonplaceholder.typicode.com/albums?userId={0}";
	    }
    }
}

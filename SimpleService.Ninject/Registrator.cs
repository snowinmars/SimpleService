using Ninject;
using SimpleService.Bll;
using SimpleService.Bll.Interfaces;
using SimpleService.Dao;
using SimpleService.Dao.Interfaces;

namespace SimpleService.Ninject
{
	public static class Registrator
	{
		public static void Register(IKernel kernel)
		{
			kernel.Bind<IUserLogic>().To<UserLogic>();
			kernel.Bind<IAlbumLogic>().To<AlbumLogic>();

			kernel.Bind<IUserDao>().To<UserDao>();
			kernel.Bind<IAlbumDao>().To<AlbumDao>();
		}
	}
}
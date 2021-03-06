﻿using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using SimpleService.Ninject;
using SimpleService.WebApi;
using System;
using System.Web;
using System.Web.Http;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace SimpleService.WebApi
{
	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

		private static IKernel kernel;

		public static IKernel GetKernel()
		{
			if (NinjectWebCommon.kernel == default(IKernel))
			{
				NinjectWebCommon.kernel = NinjectWebCommon.CreateKernel();
			}

			return NinjectWebCommon.kernel;
		}

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

			NinjectWebCommon.Bootstrapper.Initialize(NinjectWebCommon.GetKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			NinjectWebCommon.Bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			NinjectWebCommon.kernel = new StandardKernel();
			try
			{
				NinjectWebCommon.kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				NinjectWebCommon.kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				NinjectWebCommon.RegisterServices(NinjectWebCommon.kernel);
				GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(NinjectWebCommon.kernel);
				return NinjectWebCommon.kernel;
		}	
			catch
			{
				NinjectWebCommon.kernel.Dispose();
				throw;
			}
		}

		///// <summary>
		///// Load your modules or register your services here!
		///// </summary>
		///// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			Registrator.Register(kernel);
		}
	}
}
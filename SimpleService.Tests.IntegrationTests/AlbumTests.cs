using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SimpleService.Bll.Interfaces;
using SimpleService.WebApi;

namespace SimpleService.Tests.IntegrationTests
{
    public class AlbumTests
    {
	    [SetUp]
	    public void MyTestInitialize()
	    {
		    var kernel = NinjectWebCommon.GetKernel();
		    this.logic = kernel.Get<IAlbumLogic>();
	    }

		private IAlbumLogic logic;

	    [Test]
	    public void A()
	    {
		    var a = this.logic.Get(this.logic.DefaultFilter);
	    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleService.Bll.Interfaces;
using SimpleService.Dao.Interfaces;
using SimpleService.Entities;

namespace SimpleService.Bll
{
    public class AlbumLogic : IAlbumLogic
    {
	    private readonly IAlbumDao albumDao;

	    public AlbumLogic(IAlbumDao albumDao)
	    {
		    this.albumDao = albumDao;
		    this.DefaultFilter = album => true;
	    }

	    public Task<Album> Get(int id)
	    {
		    return this.albumDao.Get(id);
	    }

	    public Task<IEnumerable<Album>> Get(Func<Album, bool> filter)
	    {
			return this.albumDao.Get(filter);
	    }

	    public Func<Album, bool> DefaultFilter { get; }
    }
}

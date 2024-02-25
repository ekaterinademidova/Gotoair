using Gotoair.DataAccess.Data;
using Gotoair.DataAccess.Repository.IRepository;
using Gotoair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.DataAccess.Repository
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        private ApplicationDbContext _db;
        public RouteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Route obj)
        {
            _db.Routes.Update(obj);
        }
    }
}

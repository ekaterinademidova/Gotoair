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
    public class FlightSeatClassUserRepository : Repository<FlightSeatClassUser>, IFlightSeatClassUserRepository
    {
        private ApplicationDbContext _db;
        public FlightSeatClassUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FlightSeatClassUser obj)
        {
            _db.FlightsSeatClassesUsers.Update(obj);
        }
    }
}

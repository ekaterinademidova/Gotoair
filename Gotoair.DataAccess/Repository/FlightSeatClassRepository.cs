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
    public class FlightSeatClassRepository : Repository<FlightSeatClass>, IFlightSeatClassRepository
    {
        private ApplicationDbContext _db;
        public FlightSeatClassRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FlightSeatClass obj)
        {
            _db.FlightsSeatClasses.Update(obj);
        }
    }
}

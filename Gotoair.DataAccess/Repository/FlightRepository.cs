using Gotoair.DataAccess.Data;
using Gotoair.DataAccess.Repository.IRepository;
using Gotoair.Models;
namespace Gotoair.DataAccess.Repository
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        private ApplicationDbContext _db;
        public FlightRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Flight obj)
        {
            _db.Flights.Update(obj);
        }
    }
}

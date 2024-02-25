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
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        private ApplicationDbContext _db;
        public AirplaneRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Airplane obj)
        {
            _db.Airplanes.Update(obj);
        }
    }
}

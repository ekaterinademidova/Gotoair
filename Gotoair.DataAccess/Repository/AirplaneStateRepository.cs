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
    public class AirplaneStateRepository : Repository<AirplaneState>, IAirplaneStateRepository
    {
        private ApplicationDbContext _db;
        public AirplaneStateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AirplaneState obj)
        {
            _db.AirplaneStates.Update(obj);
        }
    }
}

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
    public class AirplaneModelRepository : Repository<AirplaneModel>, IAirplaneModelRepository
    {
        private ApplicationDbContext _db;
        public AirplaneModelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AirplaneModel obj)
        {
            _db.AirplaneModels.Update(obj);
        }
    }
}

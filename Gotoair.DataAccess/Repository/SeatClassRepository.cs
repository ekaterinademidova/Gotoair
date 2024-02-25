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
    public class SeatClassRepository : Repository<SeatClass>, ISeatClassRepository
    {
        private ApplicationDbContext _db;
        public SeatClassRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SeatClass obj)
        {
            _db.SeatClasses.Update(obj);
        }
    }
}

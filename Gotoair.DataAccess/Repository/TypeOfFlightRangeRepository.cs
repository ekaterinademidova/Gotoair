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
    public class TypeOfFlightRangeRepository : Repository<TypeOfFlightRange>, ITypeOfFlightRangeRepository
    {
        private ApplicationDbContext _db;
        public TypeOfFlightRangeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TypeOfFlightRange obj)
        {
            _db.TypesOfFlightRanges.Update(obj);
        }
    }
}

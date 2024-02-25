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
    public class TypeOfTransportationRepository : Repository<TypeOfTransportation>, ITypeOfTransportationRepository
    {
        private ApplicationDbContext _db;
        public TypeOfTransportationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TypeOfTransportation obj)
        {
            _db.TypesOfTransportations.Update(obj);
        }
    }
}

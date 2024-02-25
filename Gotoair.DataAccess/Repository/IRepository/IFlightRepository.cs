using Gotoair.Models;

namespace Gotoair.DataAccess.Repository.IRepository
{
    public interface IFlightRepository : IRepository<Flight>
    {
        void Update(Flight obj);
    }
}

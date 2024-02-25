using Gotoair.DataAccess.Data;
using Gotoair.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gotoair.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.AirplaneModels
                .Include(u => u.Company)
                .Include(u => u.CompanyId)
                .Include(u => u.TypeOfFlightRange)
                .Include(u => u.TypeOfFlightRangeId);

            _db.Airplanes
                .Include(u => u.AirplaneModel)
                .Include(u => u.AirplaneModel)
                .Include(u => u.AirplaneState)
                .Include(u => u.AirplaneStateId);

            _db.Flights
                .Include(u => u.Route)
                .Include(u => u.RouteId)
                .Include(u => u.Airplane)
                .Include(u => u.AirplaneId)
                .Include(u => u.TypeOfTransportation)
                .Include(u => u.TypeOfTransportationId);

            _db.FlightsSeatClasses
                .Include(u => u.Flight)
                .Include(u => u.FlightId)
                .Include(u => u.SeatClass)
                .Include(u => u.SeatClassId);

            _db.FlightsSeatClassesUsers
                .Include(u => u.FlightSeatClass)
                .Include(u => u.FlightSeatClassId)
                .Include(u => u.User)
                .Include(u => u.UserId);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}

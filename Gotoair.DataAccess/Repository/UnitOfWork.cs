using Gotoair.DataAccess.Data;
using Gotoair.DataAccess.Repository.IRepository;

namespace Gotoair.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICompanyRepository Company { get; private set; }
        public ITypeOfFlightRangeRepository TypeOfFlightRange { get; private set; }
        public IAirplaneStateRepository AirplaneState { get; private set; }
        public IRouteRepository Route { get; private set; }
        public IAirplaneModelRepository AirplaneModel { get; private set; }
        public IAirplaneRepository Airplane { get; private set; }
        public IFlightRepository Flight { get; private set; }
        public ITypeOfTransportationRepository TypeOfTransportation { get; private set; }
        public ISeatClassRepository SeatClass { get; private set; }
        public IFlightSeatClassRepository FlightSeatClass { get; private set; }
        public IFlightSeatClassUserRepository FlightSeatClassUser { get; private set; }

        //FlightsSeatClassesUsers
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Company = new CompanyRepository(_db);
            TypeOfFlightRange = new TypeOfFlightRangeRepository(_db);
            AirplaneState = new AirplaneStateRepository(_db);
            Route = new RouteRepository(_db);
            AirplaneModel = new AirplaneModelRepository(_db);
            Airplane = new AirplaneRepository(_db);
            Flight = new FlightRepository(_db);
            TypeOfTransportation = new TypeOfTransportationRepository(_db);
            SeatClass = new SeatClassRepository(_db);
            FlightSeatClass = new FlightSeatClassRepository(_db);
            FlightSeatClassUser = new FlightSeatClassUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

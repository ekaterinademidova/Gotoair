namespace Gotoair.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICompanyRepository Company { get; }
        ITypeOfFlightRangeRepository TypeOfFlightRange { get; }
        IAirplaneStateRepository AirplaneState { get; }
        IRouteRepository Route { get; }
        IAirplaneModelRepository AirplaneModel { get; }
        IAirplaneRepository Airplane { get; }
        IFlightRepository Flight { get; }
        ITypeOfTransportationRepository TypeOfTransportation { get; }
        ISeatClassRepository SeatClass { get; }
        IFlightSeatClassRepository FlightSeatClass { get; }
        IFlightSeatClassUserRepository FlightSeatClassUser { get; }
        void Save();
    }
}

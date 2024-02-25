using Gotoair.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gotoair.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<TypeOfFlightRange> TypesOfFlightRanges { get; set; }
        public DbSet<TypeOfTransportation> TypesOfTransportations { get; set; }
        public DbSet<AirplaneState> AirplaneStates { get; set; }
        public DbSet<AirplaneModel> AirplaneModels { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<SeatClass> SeatClasses { get; set; }
        public DbSet<FlightSeatClass> FlightsSeatClasses { get; set; }
        public DbSet<FlightSeatClassUser> FlightsSeatClassesUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Airbus", Description = "Одна из крупнейших авиастроительных компаний в мире, образованная в конце 1960-х годов путём слияния нескольких европейских авиапроизводителей. Производит пассажирские, грузовые и военно-транспортные самолёты под маркой Airbus." },
                new Company { Id = 2, Name = "ATR", Description = "Франко-итальянский производитель авиационной техники, созданный в 1981 году компаниями Aérospatiale (ныне Airbus, Франция) и Aeritalia (ныне Alenia Aeronautica, Италия). Выпускает турбовинтовые региональные пассажирские самолёты ATR 42 и ATR 72." },
                new Company { Id = 3, Name = "Saab AB", Description = "Шведская авиастроительная и оборонная компания, в прошлом также была известна своими автомобилями." },
                new Company { Id = 4, Name = "ОАК", Description = "Российская авиастроительная корпорация, одна из крупнейших в Европе. Объединяет крупные авиастроительные предприятия России." },
                new Company { Id = 5, Name = "АНТК им. О.К. Антонова", Description = "Советское, а затем украинское государственное предприятие, основной сферой деятельности которого являются грузовые авиаперевозки, а также разработка, производство и ремонт самолётов серии «Ан»." },
                new Company { Id = 6, Name = "Boeing", Description = "Американская корпорация, один из крупнейших в мире производителей авиационной, космической и военной техники." }
            );

            modelBuilder.Entity<TypeOfFlightRange>().HasData(
                new TypeOfFlightRange { Id = 1, Name = "Дальнемагистральный", Description = "Свыше 6000 км (или свыше 8000 км)." },
                new TypeOfFlightRange { Id = 2, Name = "Среднемагистральный", Description = "От 2500 до 6000 км (или до 8000 км)." },
                new TypeOfFlightRange { Id = 3, Name = "Ближнемагистральный", Description = "От 1000 до 2500 км." },
                new TypeOfFlightRange { Id = 4, Name = "Самолёты местных воздушных линий", Description = "Менее 1000 км." }
            );

            modelBuilder.Entity<TypeOfTransportation>().HasData(
                new TypeOfTransportation { Id = 1, Name = "Международный", Description = "На международных перевозках обычно используют дальне- и среднемагистральные самолёты." },
                new TypeOfTransportation { Id = 2, Name = "Региональный", Description = "На региональных перевозках обычно используют ближнемагистральные или среднемагистральные самолёты с пассажиро-вместимостью 20-100 пассажиров и полетами на расстояние до 3 тысяч километров." },
                new TypeOfTransportation { Id = 3, Name = "Местный", Description = "Самолёты, предназначенные для перевозки малого числа пассажиров (до 20) на расстояния до 1000 километров." }
            );

            modelBuilder.Entity<AirplaneState>().HasData(
                new AirplaneState { Id = 1, Name = "Активен"},
                new AirplaneState { Id = 2, Name = "В ремонте"},
                new AirplaneState { Id = 3, Name = "Списан"}
            );

            modelBuilder.Entity<AirplaneModel>().HasData(
                new AirplaneModel { Id = 1, Name = "Airbus A350-900XWB \"Carbon Fiber\"", CompanyId = 1, NumberOfFClassSeats = 40, NumberOfCClassSeats = 80, NumberOfSClassSeats = 120, TypeOfFlightRangeId = 1 },
                new AirplaneModel { Id = 2, Name = "Airbus A321neo \"EXPO 2030\"", CompanyId = 1, NumberOfFClassSeats = 30, NumberOfCClassSeats = 70, NumberOfSClassSeats = 110, TypeOfFlightRangeId = 1 },
                new AirplaneModel { Id = 3, Name = "ATR 42-300", CompanyId = 2, NumberOfFClassSeats = 20, NumberOfCClassSeats = 40, NumberOfSClassSeats = 80, TypeOfFlightRangeId = 2 },
                new AirplaneModel { Id = 4, Name = "ATR 72-200", CompanyId = 2, NumberOfFClassSeats = 40, NumberOfCClassSeats = 60, NumberOfSClassSeats = 80, TypeOfFlightRangeId = 3 },
                new AirplaneModel { Id = 5, Name = "Boeing 777", CompanyId = 6, NumberOfFClassSeats = 20, NumberOfCClassSeats = 40, NumberOfSClassSeats = 80, TypeOfFlightRangeId = 2 },
                new AirplaneModel { Id = 6, Name = "Boeing Bird of Prey", CompanyId = 6, NumberOfFClassSeats = 40, NumberOfCClassSeats = 60, NumberOfSClassSeats = 80, TypeOfFlightRangeId = 3 }
            );

            modelBuilder.Entity<Airplane>().HasData(
                new Airplane { Id = 1, SerialNumber = "DE23OI9", AirplaneModelId = 1, DateOfManufacture = DateTime.Today, AirplaneStateId = 1},
                new Airplane { Id = 2, SerialNumber = "V098GF1", AirplaneModelId = 2, DateOfManufacture = DateTime.Today, AirplaneStateId = 2 },
                new Airplane { Id = 3, SerialNumber = "NBP345Q", AirplaneModelId = 3, DateOfManufacture = DateTime.Today, AirplaneStateId = 3 },
                new Airplane { Id = 4, SerialNumber = "3423OI9", AirplaneModelId = 4, DateOfManufacture = DateTime.Today, AirplaneStateId = 1 },
                new Airplane { Id = 5, SerialNumber = "V066GF1", AirplaneModelId = 2, DateOfManufacture = DateTime.Today, AirplaneStateId = 2 },
                new Airplane { Id = 6, SerialNumber = "00P345Q", AirplaneModelId = 3, DateOfManufacture = DateTime.Today, AirplaneStateId = 3 }
            );

            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, Name = "Аэропорт Хитроу - Аэропорт Брюссель", AddressFrom = "Лондон", AddressTo = "Брюссель" },
                new Route { Id = 2, Name = "Аэропорт Эдинбург - Аэропорт имени Франсишку ди Са Карнейру", AddressFrom = "Эдинбург", AddressTo = "Порту" },
                new Route { Id = 3, Name = "Международный аэропорт Бристоль - Аэропорт Фуэртевентура", AddressFrom = "Бристоль", AddressTo = "Пуэрто-дель-Росарио" },
                new Route { Id = 4, Name = "Аэропорт Лондон-Сити - Аэропорт Эдинбург", AddressFrom = "Лондон", AddressTo = "Эдинбург" },
                new Route { Id = 5, Name = "Аэропорт Фуэртевентура - Аэропорт Брюссель", AddressFrom = "Пуэрто-дель-Росарио", AddressTo = "Брюссель" }
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight { Id = 1, RouteId = 1, AirplaneId = 1, TypeOfTransportationId = 1, DateAndTimeStart = DateTime.Now.AddDays(3), DateAndTimeEnd = DateTime.Now.AddDays(4), FreeFSeats = new int[40], FreeCSeats = new int[80], FreeSSeats = new int[120] },
                new Flight { Id = 2, RouteId = 2, AirplaneId = 2, TypeOfTransportationId = 3, DateAndTimeStart = DateTime.Now.AddDays(5), DateAndTimeEnd = DateTime.Now.AddDays(6), FreeFSeats = new int[30], FreeCSeats = new int[70], FreeSSeats = new int[110] },
                new Flight { Id = 3, RouteId = 3, AirplaneId = 3, TypeOfTransportationId = 2, DateAndTimeStart = DateTime.Now.AddDays(9), DateAndTimeEnd = DateTime.Now.AddDays(10), FreeFSeats = new int[20], FreeCSeats = new int[40], FreeSSeats = new int[80] },
                new Flight { Id = 4, RouteId = 4, AirplaneId = 1, TypeOfTransportationId = 3, DateAndTimeStart = DateTime.Now.AddDays(15), DateAndTimeEnd = DateTime.Now.AddDays(16), FreeFSeats = new int[40], FreeCSeats = new int[80], FreeSSeats = new int[120] },
                new Flight { Id = 5, RouteId = 2, AirplaneId = 5, TypeOfTransportationId = 1, DateAndTimeStart = DateTime.Now.AddDays(15), DateAndTimeEnd = DateTime.Now.AddDays(17), FreeFSeats = new int[30], FreeCSeats = new int[70], FreeSSeats = new int[110] },
                new Flight { Id = 6, RouteId = 3, AirplaneId = 6, TypeOfTransportationId = 1, DateAndTimeStart = DateTime.Now.AddDays(20), DateAndTimeEnd = DateTime.Now.AddDays(22), FreeFSeats = new int[20], FreeCSeats = new int[40], FreeSSeats = new int[80] }
            );

            modelBuilder.Entity<SeatClass>().HasData(
                new SeatClass { Id = 1, Name = "S", Description = "Эконом-класс" },
                new SeatClass { Id = 2, Name = "C", Description = "Бизнес-класс" },                
                new SeatClass { Id = 3, Name = "F", Description = "Первый класс" }
            );

            modelBuilder.Entity<FlightSeatClass>().HasData(
                new FlightSeatClass { Id = 1, FlightId = 1, SeatClassId = 3, Price = 245.50M },
                new FlightSeatClass { Id = 2, FlightId = 1, SeatClassId = 2, Price = 125.50M },
                new FlightSeatClass { Id = 3, FlightId = 1, SeatClassId = 1, Price = 65.50M },

                new FlightSeatClass { Id = 4, FlightId = 2, SeatClassId = 3, Price = 275.50M },
                new FlightSeatClass { Id = 5, FlightId = 2, SeatClassId = 2, Price = 195.00M },
                new FlightSeatClass { Id = 6, FlightId = 2, SeatClassId = 1, Price = 85.50M },

                new FlightSeatClass { Id = 7, FlightId = 3, SeatClassId = 3, Price = 175.50M },
                new FlightSeatClass { Id = 8, FlightId = 3, SeatClassId = 2, Price = 105.00M },
                new FlightSeatClass { Id = 9, FlightId = 3, SeatClassId = 1, Price = 45.50M },

                new FlightSeatClass { Id = 10, FlightId = 4, SeatClassId = 3, Price = 200.50M },
                new FlightSeatClass { Id = 11, FlightId = 4, SeatClassId = 2, Price = 135.00M },
                new FlightSeatClass { Id = 12, FlightId = 4, SeatClassId = 1, Price = 55.50M },

                new FlightSeatClass { Id = 13, FlightId = 5, SeatClassId = 3, Price = 130.50M },
                new FlightSeatClass { Id = 14, FlightId = 5, SeatClassId = 2, Price = 75.00M },
                new FlightSeatClass { Id = 15, FlightId = 5, SeatClassId = 1, Price = 25.50M },

                new FlightSeatClass { Id = 16, FlightId = 6, SeatClassId = 3, Price = 136.50M },
                new FlightSeatClass { Id = 17, FlightId = 6, SeatClassId = 2, Price = 68.00M },
                new FlightSeatClass { Id = 18, FlightId = 6, SeatClassId = 1, Price = 45.50M }
            );

            //modelBuilder.Entity<FlightSeatClassUser>().HasData(
            //    new FlightSeatClassUser { Id = 1, FlightSeatClassId = 18, UserId = "f3eaa524-8021-4c43-a2bc-12a77b74226c", SeatNumber = 42 }
            //);
        }
    }
}

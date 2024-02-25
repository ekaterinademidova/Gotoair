using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gotoair.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirplaneStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    AddressFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfFlightRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfFlightRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfTransportations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfTransportations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirplaneModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    NumberOfFClassSeats = table.Column<int>(type: "int", nullable: false),
                    NumberOfCClassSeats = table.Column<int>(type: "int", nullable: false),
                    NumberOfSClassSeats = table.Column<int>(type: "int", nullable: false),
                    TypeOfFlightRangeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirplaneModels_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirplaneModels_TypesOfFlightRanges_TypeOfFlightRangeId",
                        column: x => x.TypeOfFlightRangeId,
                        principalTable: "TypesOfFlightRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    AirplaneModelId = table.Column<int>(type: "int", nullable: false),
                    DateOfManufacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirplaneStateId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airplanes_AirplaneModels_AirplaneModelId",
                        column: x => x.AirplaneModelId,
                        principalTable: "AirplaneModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Airplanes_AirplaneStates_AirplaneStateId",
                        column: x => x.AirplaneStateId,
                        principalTable: "AirplaneStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false),
                    TypeOfTransportationId = table.Column<int>(type: "int", nullable: false),
                    DateAndTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAndTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreeFSeats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeCSeats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeSSeats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_TypesOfTransportations_TypeOfTransportationId",
                        column: x => x.TypeOfTransportationId,
                        principalTable: "TypesOfTransportations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightsSeatClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    SeatClassId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsSeatClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightsSeatClasses_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightsSeatClasses_SeatClasses_SeatClassId",
                        column: x => x.SeatClassId,
                        principalTable: "SeatClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightsSeatClassesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightSeatClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsSeatClassesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightsSeatClassesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightsSeatClassesUsers_FlightsSeatClasses_FlightSeatClassId",
                        column: x => x.FlightSeatClassId,
                        principalTable: "FlightsSeatClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AirplaneStates",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Активен" },
                    { 2, null, "В ремонте" },
                    { 3, null, "Списан" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Одна из крупнейших авиастроительных компаний в мире, образованная в конце 1960-х годов путём слияния нескольких европейских авиапроизводителей. Производит пассажирские, грузовые и военно-транспортные самолёты под маркой Airbus.", "Airbus" },
                    { 2, "Франко-итальянский производитель авиационной техники, созданный в 1981 году компаниями Aérospatiale (ныне Airbus, Франция) и Aeritalia (ныне Alenia Aeronautica, Италия). Выпускает турбовинтовые региональные пассажирские самолёты ATR 42 и ATR 72.", "ATR" },
                    { 3, "Шведская авиастроительная и оборонная компания, в прошлом также была известна своими автомобилями.", "Saab AB" },
                    { 4, "Российская авиастроительная корпорация, одна из крупнейших в Европе. Объединяет крупные авиастроительные предприятия России.", "ОАК" },
                    { 5, "Советское, а затем украинское государственное предприятие, основной сферой деятельности которого являются грузовые авиаперевозки, а также разработка, производство и ремонт самолётов серии «Ан».", "АНТК им. О.К. Антонова" },
                    { 6, "Американская корпорация, один из крупнейших в мире производителей авиационной, космической и военной техники.", "Boeing" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "AddressFrom", "AddressTo", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Лондон", "Брюссель", null, "Аэропорт Хитроу - Аэропорт Брюссель" },
                    { 2, "Эдинбург", "Порту", null, "Аэропорт Эдинбург - Аэропорт имени Франсишку ди Са Карнейру" },
                    { 3, "Бристоль", "Пуэрто-дель-Росарио", null, "Международный аэропорт Бристоль - Аэропорт Фуэртевентура" },
                    { 4, "Лондон", "Эдинбург", null, "Аэропорт Лондон-Сити - Аэропорт Эдинбург" },
                    { 5, "Пуэрто-дель-Росарио", "Брюссель", null, "Аэропорт Фуэртевентура - Аэропорт Брюссель" }
                });

            migrationBuilder.InsertData(
                table: "SeatClasses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Эконом-класс", "S" },
                    { 2, "Бизнес-класс", "C" },
                    { 3, "Первый класс", "F" }
                });

            migrationBuilder.InsertData(
                table: "TypesOfFlightRanges",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Свыше 6000 км (или свыше 8000 км).", "Дальнемагистральный" },
                    { 2, "От 2500 до 6000 км (или до 8000 км).", "Среднемагистральный" },
                    { 3, "От 1000 до 2500 км.", "Ближнемагистральный" },
                    { 4, "Менее 1000 км.", "Самолёты местных воздушных линий" }
                });

            migrationBuilder.InsertData(
                table: "TypesOfTransportations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "На международных перевозках обычно используют дальне- и среднемагистральные самолёты.", "Международный" },
                    { 2, "На региональных перевозках обычно используют ближнемагистральные или среднемагистральные самолёты с пассажиро-вместимостью 20-100 пассажиров и полетами на расстояние до 3 тысяч километров.", "Региональный" },
                    { 3, "Самолёты, предназначенные для перевозки малого числа пассажиров (до 20) на расстояния до 1000 километров.", "Местный" }
                });

            migrationBuilder.InsertData(
                table: "AirplaneModels",
                columns: new[] { "Id", "CompanyId", "Description", "Name", "NumberOfCClassSeats", "NumberOfFClassSeats", "NumberOfSClassSeats", "TypeOfFlightRangeId" },
                values: new object[,]
                {
                    { 1, 1, null, "Airbus A350-900XWB \"Carbon Fiber\"", 80, 40, 120, 1 },
                    { 2, 1, null, "Airbus A321neo \"EXPO 2030\"", 70, 30, 110, 1 },
                    { 3, 2, null, "ATR 42-300", 40, 20, 80, 2 },
                    { 4, 2, null, "ATR 72-200", 60, 40, 80, 3 },
                    { 5, 6, null, "Boeing 777", 40, 20, 80, 2 },
                    { 6, 6, null, "Boeing Bird of Prey", 60, 40, 80, 3 }
                });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirplaneModelId", "AirplaneStateId", "DateOfManufacture", "Description", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "DE23OI9" },
                    { 2, 2, 2, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "V098GF1" },
                    { 3, 3, 3, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "NBP345Q" },
                    { 4, 4, 1, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "3423OI9" },
                    { 5, 2, 2, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "V066GF1" },
                    { 6, 3, 3, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "00P345Q" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "DateAndTimeEnd", "DateAndTimeStart", "Description", "FreeCSeats", "FreeFSeats", "FreeSSeats", "RouteId", "TypeOfTransportationId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 14, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8153), new DateTime(2023, 11, 13, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8146), null, "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", 1, 1 },
                    { 2, 2, new DateTime(2023, 11, 16, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8157), new DateTime(2023, 11, 15, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8156), null, "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", 2, 3 },
                    { 3, 3, new DateTime(2023, 11, 20, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8161), new DateTime(2023, 11, 19, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8161), null, "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", 3, 2 },
                    { 4, 1, new DateTime(2023, 11, 26, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8165), new DateTime(2023, 11, 25, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8164), null, "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", 4, 3 },
                    { 5, 5, new DateTime(2023, 11, 27, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8168), new DateTime(2023, 11, 25, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8167), null, "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", 2, 1 },
                    { 6, 6, new DateTime(2023, 12, 2, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8170), new DateTime(2023, 11, 30, 3, 27, 28, 299, DateTimeKind.Local).AddTicks(8170), null, "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "FlightsSeatClasses",
                columns: new[] { "Id", "FlightId", "Price", "SeatClassId" },
                values: new object[,]
                {
                    { 1, 1, 245.50m, 3 },
                    { 2, 1, 125.50m, 2 },
                    { 3, 1, 65.50m, 1 },
                    { 4, 2, 275.50m, 3 },
                    { 5, 2, 195.00m, 2 },
                    { 6, 2, 85.50m, 1 },
                    { 7, 3, 175.50m, 3 },
                    { 8, 3, 105.00m, 2 },
                    { 9, 3, 45.50m, 1 },
                    { 10, 4, 200.50m, 3 },
                    { 11, 4, 135.00m, 2 },
                    { 12, 4, 55.50m, 1 },
                    { 13, 5, 130.50m, 3 },
                    { 14, 5, 75.00m, 2 },
                    { 15, 5, 25.50m, 1 },
                    { 16, 6, 136.50m, 3 },
                    { 17, 6, 68.00m, 2 },
                    { 18, 6, 45.50m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirplaneModels_CompanyId",
                table: "AirplaneModels",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AirplaneModels_TypeOfFlightRangeId",
                table: "AirplaneModels",
                column: "TypeOfFlightRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_AirplaneModelId",
                table: "Airplanes",
                column: "AirplaneModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_AirplaneStateId",
                table: "Airplanes",
                column: "AirplaneStateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_RouteId",
                table: "Flights",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TypeOfTransportationId",
                table: "Flights",
                column: "TypeOfTransportationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsSeatClasses_FlightId",
                table: "FlightsSeatClasses",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsSeatClasses_SeatClassId",
                table: "FlightsSeatClasses",
                column: "SeatClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsSeatClassesUsers_FlightSeatClassId",
                table: "FlightsSeatClassesUsers",
                column: "FlightSeatClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsSeatClassesUsers_UserId",
                table: "FlightsSeatClassesUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FlightsSeatClassesUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FlightsSeatClasses");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "SeatClasses");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "TypesOfTransportations");

            migrationBuilder.DropTable(
                name: "AirplaneModels");

            migrationBuilder.DropTable(
                name: "AirplaneStates");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "TypesOfFlightRanges");
        }
    }
}

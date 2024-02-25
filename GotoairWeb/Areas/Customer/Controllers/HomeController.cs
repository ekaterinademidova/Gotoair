using Gotoair.DataAccess.Repository;
using Gotoair.DataAccess.Repository.IRepository;
using Gotoair.Models;
using Gotoair.Models.ViewModels;
using Gotoair.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Collections;

namespace GotoairWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser? _user;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _user = null;
        }

        public IActionResult Index()
        {
            IEnumerable<Flight> state = _unitOfWork.Flight.GetAll(includeProperties: "Route,Airplane,TypeOfTransportation")
                .Where(f => (f.DateAndTimeStart >= DateTime.Now) && (f.FreeFSeats.Where(u => u != 0).Count() > 0 || f.FreeCSeats.Count() > 0 || f.FreeSSeats.Count() > 0))
                .OrderBy(f => f.DateAndTimeStart);



            HomeVM homeVM = new()
            {
                FlightList = state.Select(f => new FlightHomeVM
                {
                    FlightHome = f,
                    PriceS = _unitOfWork.FlightSeatClass.GetAll()
                            .Where(u => u.FlightId == f.Id && u.SeatClassId == 1)
                            .Select(u => u.Price)
                            .LastOrDefault(),
                    PriceC = _unitOfWork.FlightSeatClass.GetAll()
                            .Where(u => u.FlightId == f.Id && u.SeatClassId == 2)
                            .Select(u => u.Price)
                            .LastOrDefault(),
                    PriceF = _unitOfWork.FlightSeatClass.GetAll()
                            .Where(u => u.FlightId == f.Id && u.SeatClassId == 3)
                            .Select(u => u.Price)
                            .LastOrDefault()
                }),
                AirplaneList = _unitOfWork.Airplane.GetAll(includeProperties: "AirplaneModel,AirplaneState"),
                RouteListFrom = _unitOfWork.Route.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AddressFrom,
                    Value = u.AddressFrom
                }).Distinct(),
                RouteListTo = _unitOfWork.Route.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AddressTo,
                    Value = u.AddressTo
                }).Distinct(),
                RouteAddressTo = null,
                DateStart = DateTime.Now,
                DateEnd = DateTime.Today.AddMonths(3),
                SClassChecker = true,
                CClassChecker = true,
                FClassChecker = true,
                PriceMin = 0.00M,
                PriceMax = 13045.50M,
                User = null
            };

            //homeVM.PriceMin = homeVM.FlightList.Min(f => f.PriceS);
            //homeVM.PriceMax = homeVM.FlightList.Max(f => f.PriceF);

            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(string addressFrom, string addressTo, DateTime dateStart, DateTime dateEnd, bool cb1, bool cb2, bool cb3, decimal priceMin, decimal priceMax)
        {
            HomeVM homeVM = new()
            {
                FlightList = new List<FlightHomeVM>(),
                AirplaneList = _unitOfWork.Airplane.GetAll(includeProperties: "AirplaneModel,AirplaneState"),
                RouteListFrom = _unitOfWork.Route.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AddressFrom,
                    Value = u.AddressFrom
                }).Distinct(),
                RouteListTo = _unitOfWork.Route.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AddressTo,
                    Value = u.AddressTo
                }).Distinct(),
                RouteAddressFrom = addressFrom,
                RouteAddressTo = addressTo,
                DateStart = dateStart,
                DateEnd = dateEnd,
                SClassChecker = cb1,
                CClassChecker = cb2,
                FClassChecker = cb3,
                PriceMin = priceMin,
                PriceMax = priceMax
            };

            IEnumerable<Flight> temp = null, fPrice = null, state = null;

            if (cb1 && cb2 && cb3)
            {
                state = _unitOfWork.Flight.GetAll(includeProperties: "Route,Airplane,TypeOfTransportation")
                    .Where(u => u.FreeFSeats.Count() > 0 || u.FreeCSeats.Count() > 0 || u.FreeSSeats.Count() > 0);

                fPrice = _unitOfWork.FlightSeatClass.GetAll(includeProperties: "Flight")
                    .Where(u => u.Price >= priceMin && u.Price <= priceMax)
                    .Select(u => u.Flight);
            }
            else
            {
                if (cb1)
                {
                    temp = _unitOfWork.Flight.GetAll(includeProperties: "Route,Airplane,TypeOfTransportation").Where(f => f.FreeSSeats.Count() > 0);
                    temp = state.Concat(temp);
                    state = temp.Distinct();

                    fPrice = _unitOfWork.FlightSeatClass.GetAll(includeProperties: "Flight")
                        .Where(u => u.SeatClassId == 1 && u.Price >= priceMin && u.Price <= priceMax)
                        .Select(u => u.Flight);
                }

                if (cb2)
                {
                    temp = _unitOfWork.Flight.GetAll(includeProperties: "Route,Airplane,TypeOfTransportation").Where(f => f.FreeCSeats.Count() > 0);
                    temp = state.Concat(temp);
                    state = temp.Distinct();

                    fPrice = _unitOfWork.FlightSeatClass.GetAll(includeProperties: "Flight")
                        .Where(u => u.SeatClassId == 2 && u.Price >= priceMin && u.Price <= priceMax)
                        .Select(u => u.Flight);
                }

                if (cb3)
                {
                    temp = _unitOfWork.Flight.GetAll(includeProperties: "Route,Airplane,TypeOfTransportation").Where(f => f.FreeFSeats.Count() > 0);
                    temp = state.Concat(temp);
                    state = temp.Distinct();

                    fPrice = _unitOfWork.FlightSeatClass.GetAll(includeProperties: "Flight")
                        .Where(u => u.SeatClassId == 3 && u.Price >= priceMin && u.Price <= priceMax)
                        .Select(u => u.Flight);
                }
            }


            homeVM.FlightList = state.Intersect(fPrice).Select(f => new FlightHomeVM
            {
                FlightHome = f,
                PriceS = _unitOfWork.FlightSeatClass.GetAll()
                    .Where(u => u.FlightId == f.Id && u.SeatClassId == 1)
                    .Select(u => u.Price)
                    .First(),
                            PriceC = _unitOfWork.FlightSeatClass.GetAll()
                    .Where(u => u.FlightId == f.Id && u.SeatClassId == 2)
                    .Select(u => u.Price)
                    .First(),
                            PriceF = _unitOfWork.FlightSeatClass.GetAll()
                    .Where(u => u.FlightId == f.Id && u.SeatClassId == 3)
                    .Select(u => u.Price)
                    .First()
            });


            homeVM.FlightList = homeVM.FlightList.Where(f => f.FlightHome.DateAndTimeStart >= dateStart && f.FlightHome.DateAndTimeEnd <= dateEnd);
            if (addressFrom != null) homeVM.FlightList = homeVM.FlightList.Where(f => f.FlightHome.Route.AddressFrom == addressFrom);
            if (addressTo != null) homeVM.FlightList = homeVM.FlightList.Where(f => f.FlightHome.Route.AddressTo == addressTo);

            homeVM.FlightList = homeVM.FlightList.OrderBy(u => u.FlightHome.DateAndTimeStart);

            return View(homeVM);
        }

        public async Task<IActionResult> GetUser()
        {
            _user = await _userManager.GetUserAsync(User);
            if (_user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            return View();
        }

        [Authorize(Roles = SD.Role_Customer)]
        public async Task<IActionResult> Order(int flightId)
        {
            await GetUser();
            OrderVM orderVM = new()
            {
                Flight = _unitOfWork.Flight.Get(f => f.Id == flightId, includeProperties: "Route,Airplane"),
                User = _user
            };


            orderVM.NumberOfFreeFSeats = orderVM.Flight.FreeFSeats.Count();
            orderVM.NumberOfFreeCSeats = orderVM.Flight.FreeCSeats.Count();
            orderVM.NumberOfFreeSSeats = orderVM.Flight.FreeSSeats.Count();
            
            return View(orderVM);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Customer)]
        public async Task<IActionResult> Order(OrderVM orderVM, string seatClass, int seatChoice)
        {
            await GetUser();
            orderVM.Flight = _unitOfWork.Flight.Get(f => f.Id == orderVM.FlightId, includeProperties: "Route,Airplane");
            orderVM.User = _user;

            if (ModelState.IsValid)
            {
                bool success = false;
                if (seatClass == "S")
                {
                    for (int i = 0; i < orderVM.Flight.FreeSSeats.Count(); i++)
                    {
                        if (orderVM.Flight.FreeSSeats[i] == seatChoice)
                        {
                            int fsId = _unitOfWork.FlightSeatClass.GetAll().Where(u => u.FlightId == orderVM.FlightId && u.SeatClassId == 1).Select(u => u.Id).FirstOrDefault();

                            FlightSeatClassUser fsu = new()
                            {
                                FlightSeatClassId = fsId,
                                UserId = _user.Id,
                                SeatNumber = seatChoice
                            };

                            _unitOfWork.FlightSeatClassUser.Add(fsu);

                            var temp = new List<int>(orderVM.Flight.FreeSSeats);
                            temp.RemoveAt(i);
                            Flight f = _unitOfWork.Flight.Get(u => u.Id == orderVM.FlightId);
                            f.FreeSSeats = temp.ToArray();
                            _unitOfWork.Flight.Update(f);
                            success = true;
                        }
                    }
                    if (!success)
                    {
                        ModelState.AddModelError("all", "Место забронировано. Выберите, пожалуйста, другое");
                        return View(orderVM);
                    }
                } 
                else if (seatClass == "C")
                {
                    for (int i = 0; i < orderVM.Flight.FreeCSeats.Count(); i++)
                    {
                        if (orderVM.Flight.FreeCSeats[i] == seatChoice)
                        {
                            int fsId = _unitOfWork.FlightSeatClass.GetAll().Where(u => u.FlightId == orderVM.FlightId && u.SeatClassId == 2).Select(u => u.Id).FirstOrDefault();

                            FlightSeatClassUser fsu = new()
                            {
                                FlightSeatClassId = fsId,
                                UserId = _user.Id,
                                SeatNumber = seatChoice
                            };

                            _unitOfWork.FlightSeatClassUser.Add(fsu);

                            var temp = new List<int>(orderVM.Flight.FreeCSeats);
                            temp.RemoveAt(i);
                            Flight f = _unitOfWork.Flight.Get(u => u.Id == orderVM.FlightId);
                            f.FreeCSeats = temp.ToArray();
                            _unitOfWork.Flight.Update(f);
                            success = true;
                        }
                    }
                    if (!success)
                    {
                        ModelState.AddModelError("all", "Место забронировано. Выберите, пожалуйста, другое");
                        return View(orderVM);
                    }
                } 
                else if (seatClass == "F")
                {
                    for (int i = 0; i < orderVM.Flight.FreeFSeats.Count(); i++)
                    {
                        if (orderVM.Flight.FreeFSeats[i] == seatChoice)
                        {
                            int fsId = _unitOfWork.FlightSeatClass.GetAll().Where(u => u.FlightId == orderVM.FlightId && u.SeatClassId == 3).Select(u => u.Id).FirstOrDefault();

                            FlightSeatClassUser fsu = new()
                            {
                                FlightSeatClassId = fsId,
                                UserId = _user.Id,
                                SeatNumber = seatChoice
                            };

                            _unitOfWork.FlightSeatClassUser.Add(fsu);

                            var temp = new List<int>(orderVM.Flight.FreeFSeats);
                            temp.RemoveAt(i);
                            Flight f = _unitOfWork.Flight.Get(u => u.Id == orderVM.FlightId);
                            f.FreeFSeats = temp.ToArray();
                            _unitOfWork.Flight.Update(f);
                            success = true;
                        }
                    }
                    if (!success)
                    {
                        ModelState.AddModelError("all", "Место забронировано. Выберите, пожалуйста, другое");
                        return View(orderVM);
                    }
                }
                TempData["success"] = "Заказ оформлен";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(orderVM);

        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

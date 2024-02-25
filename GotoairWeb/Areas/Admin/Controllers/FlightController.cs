using Microsoft.AspNetCore.Mvc;
using Gotoair.Models;
using Gotoair.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gotoair.Models.ViewModels;
using Gotoair.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace GotoairWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class FlightController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Flight> objFlightList = _unitOfWork.Flight.GetAll(includeProperties: "Route,Airplane,TypeOfTransportation").ToList();
            return View(objFlightList);
        }

        public IActionResult Upsert(int? id)
        {
            FlightVM flightVM = new()
            {
                RouteList = _unitOfWork.Route.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                AirplaneList = _unitOfWork.Airplane.GetAll(includeProperties: "AirplaneModel,AirplaneState").Select(u => new SelectListItem
                {
                    Text = u.SerialNumber + " (" + u.AirplaneState.Name + ")",
                    Value = u.Id.ToString()
                }),
                TypeOfTransportationList = _unitOfWork.TypeOfTransportation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                PriceF = 0.00M,
                PriceC = 0.00M,
                PriceS = 0.00M,
                Flight = new Flight()
            };
            if (id == null || id == 0)
            {
                //create            
                flightVM.Flight.DateAndTimeStart = DateTime.Now;
                flightVM.Flight.DateAndTimeEnd = DateTime.Now;

                return View(flightVM);
            }
            else
            {
                //update
                flightVM.Flight = _unitOfWork.Flight.Get(u => u.Id == id);

                FlightSeatClass fsS = _unitOfWork.FlightSeatClass.Get(u => u.FlightId == id && u.SeatClassId == 1);
                FlightSeatClass fsC = _unitOfWork.FlightSeatClass.Get(u => u.FlightId == id && u.SeatClassId == 2);
                FlightSeatClass fsF = _unitOfWork.FlightSeatClass.Get(u => u.FlightId == id && u.SeatClassId == 3);

                flightVM.PriceS = fsS.Price;
                flightVM.PriceC = fsC.Price;
                flightVM.PriceF = fsF.Price;

                return View(flightVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(FlightVM flightVM)
        {
            if (flightVM.Flight.DateAndTimeStart == flightVM.Flight.DateAndTimeEnd)
            {
                ModelState.AddModelError("flight.DateAndTimeEnd", "Дата и время прибытия должны быть позднее даты и времени отправки");
            }

            if (flightVM.PriceS > flightVM.PriceC)
            {
                ModelState.AddModelError("priceC", "Цена билета бизнес-класса должна быть выше либо равна цене эконом-класса");
            }

            if (flightVM.PriceC > flightVM.PriceF)
            {
                ModelState.AddModelError("priceF", "Цена билета первого класса должна быть выше либо равна цене бизнес-класса");
            }

            if (ModelState.IsValid)
            {
                if (flightVM.Flight.Id == 0)
                {
                    Airplane plane = _unitOfWork.Airplane.Get(u => u.Id == flightVM.Flight.AirplaneId);
                    AirplaneModel model = _unitOfWork.AirplaneModel.Get(u => u.Id == plane.AirplaneModelId);

                    int[] temp = new int[model.NumberOfSClassSeats];
                    for (int i = 0; i < model.NumberOfSClassSeats; i++)
                    {
                        temp[i] = i + 1;
                    } 
                    flightVM.Flight.FreeSSeats = temp;

                    temp = new int[model.NumberOfCClassSeats];
                    for (int i = 0; i < model.NumberOfCClassSeats; i++)
                    {
                        temp[i] = i + 1;
                    }
                    flightVM.Flight.FreeCSeats = temp;

                    temp = new int[model.NumberOfFClassSeats];
                    for (int i = 0; i < model.NumberOfFClassSeats; i++)
                    {
                        temp[i] = i + 1;
                    }
                    flightVM.Flight.FreeFSeats = temp;

                    _unitOfWork.Flight.Add(flightVM.Flight);
                    _unitOfWork.Save();
                    TempData["success"] = "Рейс создан успешно";

                    Flight last = _unitOfWork.Flight.GetAll().LastOrDefault();


                    FlightSeatClass fsS = new()
                    {
                        FlightId = last.Id,
                        SeatClassId = 1,
                        Price = flightVM.PriceS
                    };
                    _unitOfWork.FlightSeatClass.Add(fsS);

                    FlightSeatClass fsC = new()
                    {
                        FlightId = last.Id,
                        SeatClassId = 2,
                        Price = flightVM.PriceC
                    };
                    _unitOfWork.FlightSeatClass.Add(fsC);

                    FlightSeatClass fsF = new()
                    {
                        FlightId = last.Id,
                        SeatClassId = 3,
                        Price = flightVM.PriceF
                    };
                    _unitOfWork.FlightSeatClass.Add(fsF);
                }
                else
                {
                    _unitOfWork.Flight.Update(flightVM.Flight);
                    TempData["success"] = "Рейс обновлён успешно";

                    FlightSeatClass fsS = new()
                    {
                        FlightId = flightVM.Flight.Id,
                        SeatClassId = 1,
                        Price = flightVM.PriceS
                    };
                    _unitOfWork.FlightSeatClass.Add(fsS);

                    FlightSeatClass fsC = new()
                    {
                        FlightId = flightVM.Flight.Id,
                        SeatClassId = 2,
                        Price = flightVM.PriceC
                    };
                    _unitOfWork.FlightSeatClass.Add(fsC);

                    FlightSeatClass fsF = new()
                    {
                        FlightId = flightVM.Flight.Id,
                        SeatClassId = 3,
                        Price = flightVM.PriceF
                    };
                    _unitOfWork.FlightSeatClass.Add(fsF);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                flightVM.RouteList = _unitOfWork.Route.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                flightVM.AirplaneList = _unitOfWork.Airplane.GetAll(includeProperties: "AirplaneModel,AirplaneState").Select(u => new SelectListItem
                {
                    Text = u.SerialNumber + " (" +  u.AirplaneState.Name + ")",
                    Value = u.Id.ToString()
                });
                flightVM.TypeOfTransportationList = _unitOfWork.TypeOfTransportation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(flightVM);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Flight> objFlightList = _unitOfWork.Flight.GetAll(includeProperties: "Route,Airplane,TypeOfTransportation").ToList();
            return Json(new { data = objFlightList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var flightToBeDeleted = _unitOfWork.Flight.Get(u => u.Id == id);
            if (flightToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            _unitOfWork.Flight.Remove(flightToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Успешно удалено" });
        }
        #endregion
    }
}

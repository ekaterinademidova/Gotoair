using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Gotoair.DataAccess.Data;
using Gotoair.Models;
using Gotoair.DataAccess.Repository.IRepository;
using Gotoair.Utility;
using Microsoft.AspNetCore.Authorization;
using Gotoair.Models.ViewModels;

namespace GotoairWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class RouteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Gotoair.Models.Route> objRouteList = _unitOfWork.Route.GetAll().ToList();
            return View(objRouteList);
        }

        public IActionResult Upsert(int? id)
        {
            Gotoair.Models.Route? route = new();
            if (id == null || id == 0)
            {
                //create
                return View(route);
            }
            else
            {
                //update
                route = _unitOfWork.Route.Get(u => u.Id == id);
                if (route == null)
                {
                    return NotFound();
                }
                return View(route);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Gotoair.Models.Route obj)
        {
            if (obj.AddressFrom == obj.AddressTo)
            {
                ModelState.AddModelError("AddressTo", "Место отправления и место прибытия не должны быть одинаковы");
            }
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Route.Add(obj);
                    TempData["success"] = "Маршрут создан успешно";
                }
                else
                {
                    _unitOfWork.Route.Update(obj);
                    TempData["success"] = "Маршрут обновлён успешно";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Gotoair.Models.Route> objRouteList = _unitOfWork.Route.GetAll().ToList();
            return Json(new { data = objRouteList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var routeToBeDeleted = _unitOfWork.Route.Get(u => u.Id == id);
            if (routeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            _unitOfWork.Route.Remove(routeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Успешно удалено" });
        }
        #endregion
    }
}

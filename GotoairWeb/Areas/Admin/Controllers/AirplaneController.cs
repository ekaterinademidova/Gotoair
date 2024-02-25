using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Gotoair.DataAccess.Data;
using Gotoair.Models;
using Gotoair.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gotoair.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Gotoair.Utility;
using Microsoft.AspNetCore.Authorization;

namespace GotoairWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AirplaneController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirplaneController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Airplane> objAirplaneList = _unitOfWork.Airplane.GetAll(includeProperties: "AirplaneModel,AirplaneState").ToList();
            return View(objAirplaneList);
        }

        public IActionResult Upsert(int? id)
        {
            AirplaneVM airplaneVM = new()
            {
                AirplaneModelList = _unitOfWork.AirplaneModel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                AirplaneStateList = _unitOfWork.AirplaneState.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Airplane = new Airplane()
            };
            if (id == null || id == 0)
            {
                //create
                return View(airplaneVM);
            }
            else
            {
                //update
                airplaneVM.Airplane = _unitOfWork.Airplane.Get(u => u.Id == id);
                return View(airplaneVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(AirplaneVM airplaneVM)
        {
            if (ModelState.IsValid)
            {
                if (airplaneVM.Airplane.Id == 0)
                {
                    _unitOfWork.Airplane.Add(airplaneVM.Airplane);
                    TempData["success"] = "Самолёт создан успешно";
                }
                else
                {
                    _unitOfWork.Airplane.Update(airplaneVM.Airplane);
                    TempData["success"] = "Самолёт обновлён успешно";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                airplaneVM.AirplaneModelList = _unitOfWork.AirplaneModel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                airplaneVM.AirplaneStateList = _unitOfWork.AirplaneState.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(airplaneVM);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Airplane> objAirplaneList = _unitOfWork.Airplane.GetAll(includeProperties: "AirplaneModel,AirplaneState").ToList();
            return Json(new { data = objAirplaneList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var airplaneToBeDeleted = _unitOfWork.Airplane.Get(u => u.Id == id);
            if (airplaneToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            _unitOfWork.Airplane.Remove(airplaneToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Успешно удалено" });
        }
        #endregion
    }
}

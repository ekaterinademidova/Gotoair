using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Gotoair.DataAccess.Data;
using Gotoair.Models;
using Gotoair.DataAccess.Repository.IRepository;
using Gotoair.Models.ViewModels;
using Gotoair.Utility;
using Microsoft.AspNetCore.Authorization;

namespace GotoairWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AirplaneStateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirplaneStateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<AirplaneState> objAirplaneStateList = _unitOfWork.AirplaneState.GetAll().ToList();
            return View(objAirplaneStateList);
        }

        public IActionResult Upsert(int? id)
        {
            AirplaneState? state = new();
            if (id == null || id == 0)
            {
                //create
                return View(state);
            }
            else
            {
                //update
                state = _unitOfWork.AirplaneState.Get(u => u.Id == id);
                if (state == null)
                {
                    return NotFound();
                }
                return View(state);
            }
        }

        [HttpPost]
        public IActionResult Upsert(AirplaneState obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.AirplaneState.Add(obj);
                    TempData["success"] = "Состояние самолёта создано успешно";                    
                }
                else
                {
                    _unitOfWork.AirplaneState.Update(obj);
                    TempData["success"] = "Состояние самолёта обновлено успешно";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<AirplaneState> objAirplaneStateList = _unitOfWork.AirplaneState.GetAll().ToList();
            return Json(new { data = objAirplaneStateList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var stateToBeDeleted = _unitOfWork.AirplaneState.Get(u => u.Id == id);
            if (stateToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            _unitOfWork.AirplaneState.Remove(stateToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Успешно удалено" });
        }
        #endregion
    }
}

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
    public class AirplaneModelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirplaneModelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<AirplaneModel> objAirplaneModelList = _unitOfWork.AirplaneModel.GetAll(includeProperties: "Company,TypeOfFlightRange").ToList();
            return View(objAirplaneModelList);
        }

        public IActionResult Upsert(int? id)
        {
            AirplaneModelVM airplaneModelVM = new()
            {
                CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                TypeOfFlightRangeList = _unitOfWork.TypeOfFlightRange.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                AirplaneModel = new AirplaneModel()
            };
            if (id == null || id == 0)
            {
                //create
                return View(airplaneModelVM);
            }
            else
            {
                //update
                airplaneModelVM.AirplaneModel = _unitOfWork.AirplaneModel.Get(u => u.Id == id);
                return View(airplaneModelVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(AirplaneModelVM airplaneModelVM)
        {
            if (ModelState.IsValid)
            {
                if (airplaneModelVM.AirplaneModel.Id == 0)
                {
                    _unitOfWork.AirplaneModel.Add(airplaneModelVM.AirplaneModel);
                    TempData["success"] = "Модель самолёта создана успешно";
                }
                else
                {
                    _unitOfWork.AirplaneModel.Update(airplaneModelVM.AirplaneModel);
                    TempData["success"] = "Модель самолёта обновлена успешно";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                airplaneModelVM.CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                airplaneModelVM.TypeOfFlightRangeList = _unitOfWork.TypeOfFlightRange.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(airplaneModelVM);
            }            
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<AirplaneModel> objAirplaneModelList = _unitOfWork.AirplaneModel.GetAll(includeProperties: "Company,TypeOfFlightRange").ToList();
            return Json(new { data = objAirplaneModelList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var modelToBeDeleted = _unitOfWork.AirplaneModel.Get(u => u.Id == id);
            if (modelToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            _unitOfWork.AirplaneModel.Remove(modelToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Успешно удалено" });
        }
        #endregion
    }
}

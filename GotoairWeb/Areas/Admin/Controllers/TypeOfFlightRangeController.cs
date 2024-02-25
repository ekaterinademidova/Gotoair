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

namespace GotoairWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class TypeOfFlightRangeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeOfFlightRangeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<TypeOfFlightRange> objTypeOfFlightRangesList = _unitOfWork.TypeOfFlightRange.GetAll().ToList();
            return View(objTypeOfFlightRangesList);
        }

        public IActionResult Upsert(int? id)
        {
            TypeOfFlightRange? type = new();
            if (id == null || id == 0)
            {
                //create
                return View(type);
            }
            else
            {
                //update
                type = _unitOfWork.TypeOfFlightRange.Get(u => u.Id == id);
                if (type == null)
                {
                    return NotFound();
                }
                return View(type);
            }
        }

        [HttpPost]
        public IActionResult Upsert(TypeOfFlightRange obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.TypeOfFlightRange.Add(obj);
                    TempData["success"] = "Тип дальности полёта создан успешно";
                }
                else
                {
                    _unitOfWork.TypeOfFlightRange.Update(obj);
                    TempData["success"] = "Тип дальности полёта обновлён успешно";
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
            List<TypeOfFlightRange> objTypeOfFlightRangeList = _unitOfWork.TypeOfFlightRange.GetAll().ToList();
            return Json(new { data = objTypeOfFlightRangeList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var typeToBeDeleted = _unitOfWork.TypeOfFlightRange.Get(u => u.Id == id);
            if (typeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            _unitOfWork.TypeOfFlightRange.Remove(typeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Успешно удалено" });
        }
        #endregion
    }
}

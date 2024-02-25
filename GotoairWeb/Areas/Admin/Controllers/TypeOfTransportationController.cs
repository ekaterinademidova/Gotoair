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
    public class TypeOfTransportationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeOfTransportationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<TypeOfTransportation> objTypeOfTransportationList = _unitOfWork.TypeOfTransportation.GetAll().ToList();
            return View(objTypeOfTransportationList);
        }

        public IActionResult Upsert(int? id)
        {
            TypeOfTransportation? type = new();
            if (id == null || id == 0)
            {
                //create
                return View(type);
            }
            else
            {
                //update
                type = _unitOfWork.TypeOfTransportation.Get(u => u.Id == id);
                if (type == null)
                {
                    return NotFound();
                }
                return View(type);
            }
        }

        [HttpPost]
        public IActionResult Upsert(TypeOfTransportation obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.TypeOfTransportation.Add(obj);
                    TempData["success"] = "Тип рейса создан успешно";
                }
                else
                {
                    _unitOfWork.TypeOfTransportation.Update(obj);
                    TempData["success"] = "Тип рейса обновлён успешно";
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
            List<TypeOfTransportation> objTypeOfTransportationList = _unitOfWork.TypeOfTransportation.GetAll().ToList();
            return Json(new { data = objTypeOfTransportationList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var typeToBeDeleted = _unitOfWork.TypeOfTransportation.Get(u => u.Id == id);
            if (typeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            _unitOfWork.TypeOfTransportation.Remove(typeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Успешно удалено" });
        }
        #endregion
    }
}

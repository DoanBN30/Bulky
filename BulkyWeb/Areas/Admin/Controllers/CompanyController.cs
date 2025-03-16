using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            
            return View(objCompanyList);
        }
        public IActionResult UpSert(int? id)
        {
            Company company = new Company();
            if (id == null || id == 0)
            {
                //Create
                return View(company);
            }
            else
            {
                //Update
                company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(company);
            }
        }

        [HttpPost]
        public IActionResult UpSert(Company company)
        {

            if (ModelState.IsValid)
            {
                
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company has created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                company = new Company();
                return View(company);
            }
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        #endregion

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Company CompanyToBeDelete = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyToBeDelete == null)
            {
                return Json(new { Success = false, message = "Error when deleting" });
            }
            
            _unitOfWork.Company.Remove(CompanyToBeDelete);
            _unitOfWork.Save();
            return Json(new { Success = true, message = "Delete successfull" });
        }
    }
}

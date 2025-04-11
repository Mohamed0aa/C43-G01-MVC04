using App.Buss.DTO;
using App.Buss.Interfaces;
using App.Buss.Repo;
using App.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.PR.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo _DeptRepo;

        public DepartmentController(IDepartmentRepo DeptRepo)
        {
            _DeptRepo = DeptRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _DeptRepo.GetAll();
            return View(departments);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmnetDto model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            else
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    Description = model.Description,
                };
                var count=_DeptRepo.Add(department);
                if(count >0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details()
        {

            return View();

        }
    }
}

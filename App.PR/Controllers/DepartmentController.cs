using App.Buss.DTO;
using App.Buss.Interfaces;
using App.Buss.Repo;
using App.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.PR.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentRepo _DeptRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepo.GetAll();
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
                var department= _mapper.Map<Department>(model);
                //var department = new Department()
                //{
                //    Code = model.Code,
                //    Name = model.Name,
                //    Description = model.Description,
                //};
                var count= _unitOfWork.DepartmentRepo.Add(department);
                if(count >0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id,String ActionNmae)
        {
            if (id == null) return BadRequest();
            var department = _unitOfWork.DepartmentRepo.GetById(id.Value);

            if (department == null) return NotFound();

            return View(ActionNmae,department);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id == null) return BadRequest();
            //var department = _DeptRepo.GetById(id.Value);

            //if (department == null) return NotFound();

            return Details( id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//prvent any thing out of project  to request this action
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            else
            {
                if (id != department.Id) return BadRequest();
                var count = _unitOfWork.DepartmentRepo.Update(department);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(department);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]//prvent any thing out of project  to request this action
        //public IActionResult Edit([FromRoute] int id, UpdeateDTO model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new BadRequestResult();
        //    }
        //        var department = new Department
        //        {
        //            Id =id,
        //            Name=model.Name,
        //            Description=model.Description,
        //            Code=model.Code,
        //        };
        //        var count = _DeptRepo.Update(department);
        //        if (count > 0)
        //            return RedirectToAction("Index");
        //    return View(model);

        //}

        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {
            //if (id == null) return BadRequest();
            //var department = _DeptRepo.GetById(id.Value);

            //if (department == null) return NotFound();

            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//prvent any thing out of project  to request this action
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            else
            {
                if (id != department.Id) return BadRequest();
                var count = _unitOfWork.DepartmentRepo.Delete(department);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(department);
        }

    }

}


using App.Buss.DTO;
using App.Buss.Interfaces;
using App.Buss.Repo;
using App.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.PR.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Index()
        {
            var departments =await _unitOfWork.DepartmentRepo.GetAllAsync();
            return View(departments);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(CreateDepartmnetDto model)
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
                 await _unitOfWork.DepartmentRepo.AddAsync(department);
                var count = _unitOfWork.EmployeeRepo.Save();
                if (count >0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id,String ActionNmae)
        {
            if (id == null) return BadRequest();
            var department = await _unitOfWork.DepartmentRepo.GetByIdAsync(id.Value);

            if (department == null) return NotFound();

            return View(ActionNmae,department);
        }

        [HttpGet]
        public Task<IActionResult> Edit(int? id)
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
                _unitOfWork.DepartmentRepo.Update(department);
                var count = _unitOfWork.EmployeeRepo.Save();
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
        public Task<IActionResult> Delete([FromRoute] int? id)
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
                _unitOfWork.DepartmentRepo.Delete(department);
                var count = _unitOfWork.EmployeeRepo.Save();
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(department);
        }

    }

}


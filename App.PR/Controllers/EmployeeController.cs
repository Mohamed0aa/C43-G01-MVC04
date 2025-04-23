using App.Buss.DTO;
using App.Buss.Interfaces;
using App.Data.Models;
using App.PR.Add;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.PR.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {
        //private readonly IEmployeeRepo _EmpRepo;

        //private readonly IDepartmentRepo _DeptRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;
        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            //_EmpRepo = EmpRepo;
            //_DeptRepo = DeptRepo;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        public async Task<IActionResult> Index(string? Search)
        {
            
            if (string.IsNullOrEmpty(Search))
            {
                var Employees =await _unitOfWork.EmployeeRepo.GetAllAsync();
                return View(Employees);
            }
            else
            {
                var Employee=await _unitOfWork.EmployeeRepo.GetByNameAsync(Search);
                return View(Employee);
            }
              
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var department =await  _unitOfWork.DepartmentRepo.GetAllAsync();
             ViewData["departments"] = department;
            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            else
            {
                if (model.Image is not null)
                { model.ImageName= DocmentManage.Upload(model.Image); }

                var employee = _Mapper.Map<Employee>(model);
                //var employee = new Employee()
                //{

                //    Name = model.Name,
                //    Age = model.Age,
                //    Email = model.Email,
                //    Phone = model.Phone,
                //    Dept_ID=model.Dept_id
                //};
                await _unitOfWork.EmployeeRepo.AddAsync(employee);
                int count = _unitOfWork.EmployeeRepo.Save();
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id, String ActionNmae)
        {
            var department =await _unitOfWork.DepartmentRepo.GetAllAsync();
            ViewData["departments"] = department;
            if (id == null) return BadRequest();
            var emp =await _unitOfWork.EmployeeRepo.GetByIdAsync(id.Value);
            var employee = _Mapper.Map<CreateEmployeeDto>(emp);

            if (employee == null) return NotFound();

            return View(ActionNmae, employee);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var department =await _unitOfWork.DepartmentRepo.GetAllAsync();
            ViewData["departments"] = department;
            //if (id == null) return BadRequest();
            //var department = _DeptRepo.GetById(id.Value);

            //if (department == null) return NotFound();

            return await Details(id, "Edit");
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int? id,CreateEmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (employee.ImageName is not null &&employee.Image is not null) { DocmentManage.Delete(employee.ImageName); }

                if(employee.Image is not null )
                {
                    employee.ImageName=DocmentManage.Upload(employee.Image);
                }
                var emp = _Mapper.Map<Employee>(employee);

                if (id != employee.Id) return BadRequest();
                _unitOfWork.EmployeeRepo.Update(emp);
                var count = _unitOfWork.EmployeeRepo.Save();
                if (count > 0)
                    return RedirectToAction("Index");
                else
                    return BadRequest();
            }
            //return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//prvent any thing out of project  to request this action
        public IActionResult Delete([FromRoute] int id, CreateEmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            else
            {
                var emp = _Mapper.Map<Employee>(employee);
                if (id != employee.Id) return BadRequest();
                 _unitOfWork.EmployeeRepo.Delete(emp);
                var count = _unitOfWork.EmployeeRepo.Save();
                if (count > 0)
                {
                    if(emp.ImageName is  not null) 
                    DocmentManage.Delete(emp.ImageName);

                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }


    }
}

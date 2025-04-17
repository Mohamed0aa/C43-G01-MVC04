using App.Buss.DTO;
using App.Buss.Interfaces;
using App.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.PR.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _EmpRepo;

        private readonly IDepartmentRepo _DeptRepo;
        private readonly IMapper _Mapper;
        public EmployeeController(IEmployeeRepo EmpRepo, IDepartmentRepo DeptRepo,IMapper mapper)
        {
            _EmpRepo = EmpRepo;
            _DeptRepo = DeptRepo;
            _Mapper = mapper;
        }

        public IActionResult Index(string? Search)
        {
            
            if (string.IsNullOrEmpty(Search))
            {
                var Employees = _EmpRepo.GetAll();
                return View(Employees);
            }
            else
            {
                var Employee=_EmpRepo.GetByName(Search);
                return View(Employee);
            }
              
        }


        [HttpGet]
        public IActionResult Create()
        {
            var department = _DeptRepo.GetAll();
             ViewData["departments"] = department;
            
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            else
            {

                var employee = _Mapper.Map<Employee>(model);
                //var employee = new Employee()
                //{

                //    Name = model.Name,
                //    Age = model.Age,
                //    Email = model.Email,
                //    Phone = model.Phone,
                //    Dept_ID=model.Dept_id
                //};
                var count = _EmpRepo.Add(employee);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id, String ActionNmae)
        {
            var department = _DeptRepo.GetAll();
            ViewData["departments"] = department;
            if (id == null) return BadRequest();
            var employee = _EmpRepo.GetById(id.Value);

            if (employee == null) return NotFound();

            return View(ActionNmae, employee);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var department = _DeptRepo.GetAll();
            ViewData["departments"] = department;
            //if (id == null) return BadRequest();
            //var department = _DeptRepo.GetById(id.Value);

            //if (department == null) return NotFound();

            return Details(id, "Edit");
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int? id,Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (id != employee.Id) return BadRequest();
                var count = _EmpRepo.Update(employee);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//prvent any thing out of project  to request this action
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            else
            {
                if (id != employee.Id) return BadRequest();
                var count = _EmpRepo.Delete(employee);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(employee);
        }


    }
}

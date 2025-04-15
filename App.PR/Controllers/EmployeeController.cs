using App.Buss.DTO;
using App.Buss.Interfaces;
using App.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.PR.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _EmpRepo;

        public EmployeeController(IEmployeeRepo EmpRepo)
        {
            _EmpRepo = EmpRepo;
        }

        public IActionResult Index()
        {
            var Employees = _EmpRepo.GetAll();
            return View(Employees);
        }


        [HttpGet]
        public IActionResult Create()
        {
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
                var employee = new Employee()
                {
                    
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Phone = model.Phone,
                };
                var count = _EmpRepo.Add(employee);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id, String ActionNmae)
        {
            if (id == null) return BadRequest();
            var employee = _EmpRepo.GetById(id.Value);

            if (employee == null) return NotFound();

            return View(ActionNmae, employee);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
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

using App.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.Buss.DTO
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Not Allowed Empty")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public string Phone { get; set; }

        [Display(Name = "Department")]
        public int? Dept_id { get; set; }
    }
}

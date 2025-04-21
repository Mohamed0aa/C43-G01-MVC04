using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public class Employee :BaseEntity
    {
        [Required(ErrorMessage = "Not Allowed Empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public string Phone { get; set; }
        public double? Salary { get; set; }

        bool? IsDeleted { get; set; }
        bool? IsActive { get; set; }
        [DisplayName("mo")]
        public int? Dept_ID {  get; set; }
        public Department?Department { get; set; }

        public String? ImageName {  get; set; }

        


    }
}

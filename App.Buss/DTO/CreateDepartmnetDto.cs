using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.DTO
{
    public class CreateDepartmnetDto
    {
        [Required(ErrorMessage ="Not Allowed Empty")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Not Allowed Empty")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}

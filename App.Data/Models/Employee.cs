﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public class Employee :BaseEntity
    {
        public string Name { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public double? Salary { get; set; }

        bool? IsDeleted { get; set; }
        bool? IsActive { get; set; }

        


    }
}

 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeTracker.Models
    {
        public class tbl_TimeForm
        {
            [Key]
            public int Id { get; set; }


            [Required]
            [DataType(DataType.Date)]
            public string Date { get; set; }
            [Required]

            public string Client { get; set; }
            [Required]
            public string Project { get; set; }
            [Required]
            [DataType(DataType.Duration)]
            public string Hours { get; set; }
            [Required]
            [Display(Name = "Task Description")]
            public string Task_Description { get; set; }
            public int emp_ID { get; set; }
        }
    }


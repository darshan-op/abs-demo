using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeTracker.Models
{
    public class tbl_employees
    {
       
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string email { get; set; }
        [Key]
        public int emp_ID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Hobbies")]
        public string hobbies { get; set; }
        [Required]
        [Display(Name = "Skill")]
        public string skill { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "State")]
        public string state { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal Code")]
        public string postal_code { get; set; }

        //public Timeform TimeForm{get; set;}
    }
}

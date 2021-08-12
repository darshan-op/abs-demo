using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCrud.Models
{
    public class tbl_Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Mobile { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DepId { get; set; }

        [NotMapped]
        public string Department { get; set; }

    }
}

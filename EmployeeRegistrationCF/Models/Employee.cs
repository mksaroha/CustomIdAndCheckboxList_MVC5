namespace EmployeeRegistrationCF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public string Id { get; set; }

        //public string EmployeeId { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        //[DataType(DataType.Date)]
        [Required(ErrorMessage ="Please Enter DOB")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage ="Please Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage ="Please Select Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string Hobbies { get; set; }       
    }
}

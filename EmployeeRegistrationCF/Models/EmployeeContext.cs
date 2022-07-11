namespace EmployeeRegistrationCF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=AppConnection")
        {
        }
        
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

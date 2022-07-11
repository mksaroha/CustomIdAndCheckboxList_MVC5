namespace EmployeeRegistrationCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "HobbiesId");
            DropColumn("dbo.Employees", "IsAvaliable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "IsAvaliable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "HobbiesId", c => c.Int(nullable: false));
        }
    }
}

namespace EmployeeRegistrationCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "HobbiesId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "IsAvaliable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsAvaliable");
            DropColumn("dbo.Employees", "HobbiesId");
        }
    }
}

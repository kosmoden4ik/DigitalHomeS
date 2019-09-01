namespace DigitalHomeS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.DeviceModels", "ApplicationUser_Id");
            AddForeignKey("dbo.DeviceModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DeviceModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.DeviceModels", "ApplicationUser_Id");
        }
    }
}

namespace DigitalHomeS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDBc1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DeviceModels", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.ApplicationUserDeviceModels",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        DeviceModels_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.DeviceModels_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.DeviceModels", t => t.DeviceModels_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.DeviceModels_Id);
            
            DropColumn("dbo.DeviceModels", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ApplicationUserDeviceModels", "DeviceModels_Id", "dbo.DeviceModels");
            DropForeignKey("dbo.ApplicationUserDeviceModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserDeviceModels", new[] { "DeviceModels_Id" });
            DropIndex("dbo.ApplicationUserDeviceModels", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserDeviceModels");
            CreateIndex("dbo.DeviceModels", "ApplicationUser_Id");
            AddForeignKey("dbo.DeviceModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

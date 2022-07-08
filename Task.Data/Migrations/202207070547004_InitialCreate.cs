namespace Task.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mas_City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        City_Name = c.String(nullable: false, maxLength: 50),
                        StateId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Mas_State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Mas_State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        State_Name = c.String(nullable: false, maxLength: 50),
                        CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Mas_Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Mas_Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Country_Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Mas_Gender",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Gender_Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Role_Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Tbl_Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        GenderId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Pincode = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        LastWorkingDate = c.DateTime(),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Tbl_User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        RoleId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        UserNickName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mas_State", "CountryId", "dbo.Mas_Country");
            DropForeignKey("dbo.Mas_City", "StateId", "dbo.Mas_State");
            DropIndex("dbo.Tbl_User", new[] { "Email" });
            DropIndex("dbo.Tbl_User", new[] { "Username" });
            DropIndex("dbo.Tbl_Employee", new[] { "Email" });
            DropIndex("dbo.Mas_State", new[] { "CountryId" });
            DropIndex("dbo.Mas_City", new[] { "StateId" });
            DropTable("dbo.Tbl_User");
            DropTable("dbo.Tbl_Employee");
            DropTable("dbo.Role");
            DropTable("dbo.Mas_Gender");
            DropTable("dbo.Mas_Country");
            DropTable("dbo.Mas_State");
            DropTable("dbo.Mas_City");
        }
    }
}

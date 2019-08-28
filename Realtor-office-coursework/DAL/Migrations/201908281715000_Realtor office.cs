namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Realtoroffice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Square = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountRooms = c.Int(nullable: false),
                        Bought = c.Boolean(nullable: false),
                        RealtorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Realtors", t => t.RealtorId, cascadeDelete: true)
                .Index(t => t.RealtorId);
            
            CreateTable(
                "dbo.Realtors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopperApartments",
                c => new
                    {
                        ApartmentId = c.Int(nullable: false),
                        ShopperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApartmentId, t.ShopperId })
                .ForeignKey("dbo.Apartments", t => t.ApartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.ShopperId, cascadeDelete: true)
                .Index(t => t.ApartmentId)
                .Index(t => t.ShopperId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopperApartments", "ShopperId", "dbo.Accounts");
            DropForeignKey("dbo.ShopperApartments", "ApartmentId", "dbo.Apartments");
            DropForeignKey("dbo.Apartments", "RealtorId", "dbo.Realtors");
            DropIndex("dbo.ShopperApartments", new[] { "ShopperId" });
            DropIndex("dbo.ShopperApartments", new[] { "ApartmentId" });
            DropIndex("dbo.Apartments", new[] { "RealtorId" });
            DropTable("dbo.Accounts");
            DropTable("dbo.ShopperApartments");
            DropTable("dbo.Realtors");
            DropTable("dbo.Apartments");
        }
    }
}

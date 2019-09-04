namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeshhopetbl : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Accounts", newName: "Shopper");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Shopper", newName: "Accounts");
        }
    }
}

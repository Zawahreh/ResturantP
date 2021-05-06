namespace storev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        MealId = c.Byte(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}

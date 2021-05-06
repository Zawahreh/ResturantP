namespace storev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusColumnToBills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Status");
        }
    }
}

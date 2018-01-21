namespace jARVIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDBName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShoppingListModels", newName: "ShoppingLists");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ShoppingLists", newName: "ShoppingListModels");
        }
    }
}

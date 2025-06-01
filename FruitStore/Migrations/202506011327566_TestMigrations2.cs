namespace FruitStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigrations2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fruits", "Fruits_Id", "dbo.Fruits");
            DropForeignKey("dbo.Fruits", "FruitType_Id", "dbo.FruitTypes");
            DropIndex("dbo.Fruits", new[] { "Fruits_Id" });
            DropIndex("dbo.Fruits", new[] { "FruitType_Id" });
            RenameColumn(table: "dbo.Fruits", name: "FruitType_Id", newName: "FruitTypeId");
            AlterColumn("dbo.Fruits", "FruitTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fruits", "FruitTypeId");
            AddForeignKey("dbo.Fruits", "FruitTypeId", "dbo.FruitTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Fruits", "TypeFruit");
            DropColumn("dbo.Fruits", "Fruits_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fruits", "Fruits_Id", c => c.Int());
            AddColumn("dbo.Fruits", "TypeFruit", c => c.String());
            DropForeignKey("dbo.Fruits", "FruitTypeId", "dbo.FruitTypes");
            DropIndex("dbo.Fruits", new[] { "FruitTypeId" });
            AlterColumn("dbo.Fruits", "FruitTypeId", c => c.Int());
            RenameColumn(table: "dbo.Fruits", name: "FruitTypeId", newName: "FruitType_Id");
            CreateIndex("dbo.Fruits", "FruitType_Id");
            CreateIndex("dbo.Fruits", "Fruits_Id");
            AddForeignKey("dbo.Fruits", "FruitType_Id", "dbo.FruitTypes", "Id");
            AddForeignKey("dbo.Fruits", "Fruits_Id", "dbo.Fruits", "Id");
        }
    }
}

namespace FruitStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fruits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeFruit = c.String(),
                        Fruits_Id = c.Int(),
                        FruitType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fruits", t => t.Fruits_Id)
                .ForeignKey("dbo.FruitTypes", t => t.FruitType_Id)
                .Index(t => t.Fruits_Id)
                .Index(t => t.FruitType_Id);
            
            CreateTable(
                "dbo.FruitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fruits", "FruitType_Id", "dbo.FruitTypes");
            DropForeignKey("dbo.Fruits", "Fruits_Id", "dbo.Fruits");
            DropIndex("dbo.Fruits", new[] { "FruitType_Id" });
            DropIndex("dbo.Fruits", new[] { "Fruits_Id" });
            DropTable("dbo.FruitTypes");
            DropTable("dbo.Fruits");
        }
    }
}

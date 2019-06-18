namespace ClothesDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Cat_Id, cascadeDelete: true)
                .Index(t => t.Cat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cat_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Cat_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

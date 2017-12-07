namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Magasin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Magasins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MagasinSalades",
                c => new
                    {
                        Magasin_ID = c.Int(nullable: false),
                        Salade_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Magasin_ID, t.Salade_ID })
                .ForeignKey("dbo.Magasins", t => t.Magasin_ID, cascadeDelete: true)
                .ForeignKey("dbo.Salades", t => t.Salade_ID, cascadeDelete: true)
                .Index(t => t.Magasin_ID)
                .Index(t => t.Salade_ID);
            
            AlterColumn("dbo.Salades", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Fabricants", "Nom", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MagasinSalades", "Salade_ID", "dbo.Salades");
            DropForeignKey("dbo.MagasinSalades", "Magasin_ID", "dbo.Magasins");
            DropIndex("dbo.MagasinSalades", new[] { "Salade_ID" });
            DropIndex("dbo.MagasinSalades", new[] { "Magasin_ID" });
            AlterColumn("dbo.Fabricants", "Nom", c => c.String(maxLength: 30));
            AlterColumn("dbo.Salades", "Nom", c => c.String(maxLength: 50));
            DropTable("dbo.MagasinSalades");
            DropTable("dbo.Magasins");
        }
    }
}

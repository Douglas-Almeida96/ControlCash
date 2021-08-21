namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoCartaos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TipoConsumoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoConsumoes");
            DropTable("dbo.TipoCartaos");
        }
    }
}

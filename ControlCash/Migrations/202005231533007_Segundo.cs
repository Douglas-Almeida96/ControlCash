namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segundo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstituicaoId = c.Int(nullable: false),
                        TipoCartaoId = c.Int(nullable: false),
                        Nome = c.String(),
                        Saldo = c.Double(nullable: false),
                        limite = c.Double(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCartaos", t => t.TipoCartaoId, cascadeDelete: true)
                .Index(t => t.InstituicaoId)
                .Index(t => t.TipoCartaoId);
            
            CreateTable(
                "dbo.Gastoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartaoId = c.Int(nullable: false),
                        RendaExtraId = c.Int(nullable: false),
                        Nparcelas = c.Int(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        TipoConsumoId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cartaos", t => t.CartaoId, cascadeDelete: true)
                .ForeignKey("dbo.RendaExtras", t => t.RendaExtraId, cascadeDelete: true)
                .ForeignKey("dbo.TipoConsumoes", t => t.TipoConsumoId, cascadeDelete: true)
                .Index(t => t.CartaoId)
                .Index(t => t.RendaExtraId)
                .Index(t => t.TipoConsumoId);
            
            CreateTable(
                "dbo.RendaExtras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Valor = c.Double(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gastoes", "TipoConsumoId", "dbo.TipoConsumoes");
            DropForeignKey("dbo.Gastoes", "RendaExtraId", "dbo.RendaExtras");
            DropForeignKey("dbo.Gastoes", "CartaoId", "dbo.Cartaos");
            DropForeignKey("dbo.Cartaos", "TipoCartaoId", "dbo.TipoCartaos");
            DropForeignKey("dbo.Cartaos", "InstituicaoId", "dbo.Instituicaos");
            DropIndex("dbo.Gastoes", new[] { "TipoConsumoId" });
            DropIndex("dbo.Gastoes", new[] { "RendaExtraId" });
            DropIndex("dbo.Gastoes", new[] { "CartaoId" });
            DropIndex("dbo.Cartaos", new[] { "TipoCartaoId" });
            DropIndex("dbo.Cartaos", new[] { "InstituicaoId" });
            DropTable("dbo.RendaExtras");
            DropTable("dbo.Gastoes");
            DropTable("dbo.Cartaos");
        }
    }
}

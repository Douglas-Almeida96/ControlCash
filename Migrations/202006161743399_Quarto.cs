namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nome1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tesouro_Direto",
                c => new
                    {
                        TesousoID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Titulo = c.String(),
                        Aplica_por = c.String(),
                        Valor_Aplicado = c.Single(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Preco_Compra = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TesousoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tesouro_Direto");
        }
    }
}

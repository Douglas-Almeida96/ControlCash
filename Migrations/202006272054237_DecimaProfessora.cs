namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecimaProfessora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Moedas", "InstituicaoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Moedas", "InstituicaoId");
            AddForeignKey("dbo.Moedas", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            DropColumn("dbo.Moedas", "IF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Moedas", "IF", c => c.String());
            DropForeignKey("dbo.Moedas", "InstituicaoId", "dbo.Instituicaos");
            DropIndex("dbo.Moedas", new[] { "InstituicaoId" });
            DropColumn("dbo.Moedas", "InstituicaoId");
        }
    }
}

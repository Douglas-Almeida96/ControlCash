namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sexta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Acoes_BDR_FII", "UserID", c => c.String());
            AlterColumn("dbo.Criptomoedas", "UserID", c => c.String());
            AlterColumn("dbo.Debentures", "UserID", c => c.String());
            AlterColumn("dbo.Fundoes", "UserID", c => c.String());
            AlterColumn("dbo.Moedas", "UserID", c => c.String());
            AlterColumn("dbo.Poupancas", "UserID", c => c.String());
            AlterColumn("dbo.Previdencias", "UserID", c => c.String());
            AlterColumn("dbo.Renda_Fixa_Pos", "UserID", c => c.String());
            AlterColumn("dbo.Renda_Fixa_Pre", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Renda_Fixa_Pre", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Renda_Fixa_Pos", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Previdencias", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Poupancas", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Moedas", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Fundoes", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Debentures", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Criptomoedas", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Acoes_BDR_FII", "UserID", c => c.Int(nullable: false));
        }
    }
}

namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OitavaProfessora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acoes_BDR_FII", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Criptomoedas", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Debentures", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Fundoes", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Poupancas", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Previdencias", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Renda_Fixa_Pos", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Renda_Fixa_Pre", "InstituicaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Tesouro_Direto", "InstituicaoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Acoes_BDR_FII", "InstituicaoId");
            CreateIndex("dbo.Criptomoedas", "InstituicaoId");
            CreateIndex("dbo.Debentures", "InstituicaoId");
            CreateIndex("dbo.Fundoes", "InstituicaoId");
            CreateIndex("dbo.Poupancas", "InstituicaoId");
            CreateIndex("dbo.Previdencias", "InstituicaoId");
            CreateIndex("dbo.Renda_Fixa_Pos", "InstituicaoId");
            CreateIndex("dbo.Renda_Fixa_Pre", "InstituicaoId");
            CreateIndex("dbo.Tesouro_Direto", "InstituicaoId");
            AddForeignKey("dbo.Acoes_BDR_FII", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Criptomoedas", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Debentures", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fundoes", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Poupancas", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Previdencias", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Renda_Fixa_Pos", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Renda_Fixa_Pre", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tesouro_Direto", "InstituicaoId", "dbo.Instituicaos", "Id", cascadeDelete: true);
            DropColumn("dbo.Acoes_BDR_FII", "IF");
            DropColumn("dbo.Criptomoedas", "IF");
            DropColumn("dbo.Debentures", "IF");
            DropColumn("dbo.Fundoes", "IF");
            DropColumn("dbo.Poupancas", "IF");
            DropColumn("dbo.Previdencias", "IF");
            DropColumn("dbo.Renda_Fixa_Pos", "IF");
            DropColumn("dbo.Renda_Fixa_Pre", "IF");
            DropColumn("dbo.Tesouro_Direto", "IF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tesouro_Direto", "IF", c => c.String());
            AddColumn("dbo.Renda_Fixa_Pre", "IF", c => c.String());
            AddColumn("dbo.Renda_Fixa_Pos", "IF", c => c.String());
            AddColumn("dbo.Previdencias", "IF", c => c.String());
            AddColumn("dbo.Poupancas", "IF", c => c.String());
            AddColumn("dbo.Fundoes", "IF", c => c.String());
            AddColumn("dbo.Debentures", "IF", c => c.String());
            AddColumn("dbo.Criptomoedas", "IF", c => c.String());
            AddColumn("dbo.Acoes_BDR_FII", "IF", c => c.String());
            DropForeignKey("dbo.Tesouro_Direto", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Renda_Fixa_Pre", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Renda_Fixa_Pos", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Previdencias", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Poupancas", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Fundoes", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Debentures", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Criptomoedas", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Acoes_BDR_FII", "InstituicaoId", "dbo.Instituicaos");
            DropIndex("dbo.Tesouro_Direto", new[] { "InstituicaoId" });
            DropIndex("dbo.Renda_Fixa_Pre", new[] { "InstituicaoId" });
            DropIndex("dbo.Renda_Fixa_Pos", new[] { "InstituicaoId" });
            DropIndex("dbo.Previdencias", new[] { "InstituicaoId" });
            DropIndex("dbo.Poupancas", new[] { "InstituicaoId" });
            DropIndex("dbo.Fundoes", new[] { "InstituicaoId" });
            DropIndex("dbo.Debentures", new[] { "InstituicaoId" });
            DropIndex("dbo.Criptomoedas", new[] { "InstituicaoId" });
            DropIndex("dbo.Acoes_BDR_FII", new[] { "InstituicaoId" });
            DropColumn("dbo.Tesouro_Direto", "InstituicaoId");
            DropColumn("dbo.Renda_Fixa_Pre", "InstituicaoId");
            DropColumn("dbo.Renda_Fixa_Pos", "InstituicaoId");
            DropColumn("dbo.Previdencias", "InstituicaoId");
            DropColumn("dbo.Poupancas", "InstituicaoId");
            DropColumn("dbo.Fundoes", "InstituicaoId");
            DropColumn("dbo.Debentures", "InstituicaoId");
            DropColumn("dbo.Criptomoedas", "InstituicaoId");
            DropColumn("dbo.Acoes_BDR_FII", "InstituicaoId");
        }
    }
}

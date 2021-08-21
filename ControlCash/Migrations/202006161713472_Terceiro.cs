namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acoes_BDR_FII",
                c => new
                    {
                        Acoes_BDR_FIIID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Ativo = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Preco_Compra = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        Taxa = c.Single(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Acoes_BDR_FIIID);
            
            CreateTable(
                "dbo.Criptomoedas",
                c => new
                    {
                        CriptomoedaID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Tipo_Moeda = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Preco_Compra = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CriptomoedaID);
            
            CreateTable(
                "dbo.Debentures",
                c => new
                    {
                        DebentureID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Debenture_Escolhido = c.String(),
                        Aplica_por = c.String(),
                        Valor_Aplicado = c.Single(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Preco_Compra = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DebentureID);
            
            CreateTable(
                "dbo.Fundoes",
                c => new
                    {
                        FundoID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Fundo_Escolhido = c.String(),
                        Aplica_por = c.String(),
                        Valor_Aplicado = c.Single(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Preco_Compra = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FundoID);
            
            CreateTable(
                "dbo.Moedas",
                c => new
                    {
                        MoedaID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Tipo_Moeda = c.String(),
                        Cotacao = c.Single(nullable: false),
                        Valor_Comprado = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoedaID);
            
            CreateTable(
                "dbo.Poupancas",
                c => new
                    {
                        PoupancaID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Valor_Aplicado = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PoupancaID);
            
            CreateTable(
                "dbo.Previdencias",
                c => new
                    {
                        PrevidenciaID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Fundo = c.String(),
                        Valor_Aplicado = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrevidenciaID);
            
            CreateTable(
                "dbo.Renda_Fixa_Pos",
                c => new
                    {
                        Renda_PosID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Emissor = c.String(),
                        Papel = c.String(),
                        Indexador = c.String(),
                        Porcentagem = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        Data_Venc = c.String(),
                        Valor_Aplicado = c.Single(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Renda_PosID);
            
            CreateTable(
                "dbo.Renda_Fixa_Pre",
                c => new
                    {
                        Renda_PreID = c.Int(nullable: false, identity: true),
                        IF = c.String(),
                        Emissor = c.String(),
                        Papel = c.String(),
                        Taxa_Juros_Ano = c.Single(nullable: false),
                        Data_Inicio = c.String(),
                        Data_Venc = c.String(),
                        Valor_Aplicado = c.Single(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Renda_PreID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Renda_Fixa_Pre");
            DropTable("dbo.Renda_Fixa_Pos");
            DropTable("dbo.Previdencias");
            DropTable("dbo.Poupancas");
            DropTable("dbo.Moedas");
            DropTable("dbo.Fundoes");
            DropTable("dbo.Debentures");
            DropTable("dbo.Criptomoedas");
            DropTable("dbo.Acoes_BDR_FII");
        }
    }
}

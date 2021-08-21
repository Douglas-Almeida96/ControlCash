namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecimaSegundaProfessora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionarios", "Perg1", c => c.Int(nullable: false));
            AddColumn("dbo.Questionarios", "Perg6a", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questionarios", "Perg6b", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questionarios", "Perg6c", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questionarios", "Perg6d", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questionarios", "Perg6e", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questionarios", "Perg6f", c => c.Boolean(nullable: false));
            DropColumn("dbo.Questionarios", "Perg1a");
            DropColumn("dbo.Questionarios", "Perg6");
            DropColumn("dbo.Questionarios", "Valor_Investido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questionarios", "Valor_Investido", c => c.Double(nullable: false));
            AddColumn("dbo.Questionarios", "Perg6", c => c.Int(nullable: false));
            AddColumn("dbo.Questionarios", "Perg1a", c => c.Int(nullable: false));
            DropColumn("dbo.Questionarios", "Perg6f");
            DropColumn("dbo.Questionarios", "Perg6e");
            DropColumn("dbo.Questionarios", "Perg6d");
            DropColumn("dbo.Questionarios", "Perg6c");
            DropColumn("dbo.Questionarios", "Perg6b");
            DropColumn("dbo.Questionarios", "Perg6a");
            DropColumn("dbo.Questionarios", "Perg1");
        }
    }
}

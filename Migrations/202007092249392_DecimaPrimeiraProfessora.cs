namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecimaPrimeiraProfessora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionarios", "Perg1a", c => c.Int(nullable: false));
            DropColumn("dbo.Questionarios", "Perg1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questionarios", "Perg1", c => c.Int(nullable: false));
            DropColumn("dbo.Questionarios", "Perg1a");
        }
    }
}

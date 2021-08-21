namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NonaProfessora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RendaExtras", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RendaExtras", "Descricao");
        }
    }
}

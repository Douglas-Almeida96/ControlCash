namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nome2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tesouro_Direto", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tesouro_Direto", "UserID", c => c.Int(nullable: false));
        }
    }
}

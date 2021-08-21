namespace ControlCash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setima : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questionarios",
                c => new
                    {
                        QuestID = c.Int(nullable: false, identity: true),
                        Perg1 = c.Int(nullable: false),
                        Perg2 = c.Int(nullable: false),
                        Perg3 = c.Int(nullable: false),
                        Perg4 = c.Int(nullable: false),
                        Perg5 = c.Int(nullable: false),
                        Perg6 = c.Int(nullable: false),
                        Perg7 = c.Int(nullable: false),
                        Perg8 = c.Int(nullable: false),
                        Valor_Investido = c.Double(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.QuestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questionarios");
        }
    }
}

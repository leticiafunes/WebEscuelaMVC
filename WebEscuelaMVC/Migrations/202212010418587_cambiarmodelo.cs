namespace WebEscuelaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiarmodelo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Aulas", newName: "Aula");
            AlterColumn("dbo.Aula", "Numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aula", "Numero", c => c.String(nullable: false));
            RenameTable(name: "dbo.Aula", newName: "Aulas");
        }
    }
}

namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uruns", "urun_Urunid", c => c.Int());
            CreateIndex("dbo.Uruns", "urun_Urunid");
            AddForeignKey("dbo.Uruns", "urun_Urunid", "dbo.Uruns", "Urunid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uruns", "urun_Urunid", "dbo.Uruns");
            DropIndex("dbo.Uruns", new[] { "urun_Urunid" });
            DropColumn("dbo.Uruns", "urun_Urunid");
        }
    }
}

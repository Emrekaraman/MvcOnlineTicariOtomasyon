namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class satisharaket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SatisHarakets", "Cariler_Cariid", "dbo.Carilers");
            DropForeignKey("dbo.SatisHarakets", "Personel_Personelid", "dbo.Personels");
            DropForeignKey("dbo.SatisHarakets", "Urun_Urunid", "dbo.Uruns");
            DropIndex("dbo.SatisHarakets", new[] { "Cariler_Cariid" });
            DropIndex("dbo.SatisHarakets", new[] { "Personel_Personelid" });
            DropIndex("dbo.SatisHarakets", new[] { "Urun_Urunid" });
            RenameColumn(table: "dbo.SatisHarakets", name: "Cariler_Cariid", newName: "Cariid");
            RenameColumn(table: "dbo.SatisHarakets", name: "Personel_Personelid", newName: "Personelid");
            RenameColumn(table: "dbo.SatisHarakets", name: "Urun_Urunid", newName: "Urunid");
            AlterColumn("dbo.SatisHarakets", "Cariid", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarakets", "Personelid", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarakets", "Urunid", c => c.Int(nullable: false));
            CreateIndex("dbo.SatisHarakets", "Urunid");
            CreateIndex("dbo.SatisHarakets", "Cariid");
            CreateIndex("dbo.SatisHarakets", "Personelid");
            AddForeignKey("dbo.SatisHarakets", "Cariid", "dbo.Carilers", "Cariid", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarakets", "Personelid", "dbo.Personels", "Personelid", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarakets", "Urunid", "dbo.Uruns", "Urunid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SatisHarakets", "Urunid", "dbo.Uruns");
            DropForeignKey("dbo.SatisHarakets", "Personelid", "dbo.Personels");
            DropForeignKey("dbo.SatisHarakets", "Cariid", "dbo.Carilers");
            DropIndex("dbo.SatisHarakets", new[] { "Personelid" });
            DropIndex("dbo.SatisHarakets", new[] { "Cariid" });
            DropIndex("dbo.SatisHarakets", new[] { "Urunid" });
            AlterColumn("dbo.SatisHarakets", "Urunid", c => c.Int());
            AlterColumn("dbo.SatisHarakets", "Personelid", c => c.Int());
            AlterColumn("dbo.SatisHarakets", "Cariid", c => c.Int());
            RenameColumn(table: "dbo.SatisHarakets", name: "Urunid", newName: "Urun_Urunid");
            RenameColumn(table: "dbo.SatisHarakets", name: "Personelid", newName: "Personel_Personelid");
            RenameColumn(table: "dbo.SatisHarakets", name: "Cariid", newName: "Cariler_Cariid");
            CreateIndex("dbo.SatisHarakets", "Urun_Urunid");
            CreateIndex("dbo.SatisHarakets", "Personel_Personelid");
            CreateIndex("dbo.SatisHarakets", "Cariler_Cariid");
            AddForeignKey("dbo.SatisHarakets", "Urun_Urunid", "dbo.Uruns", "Urunid");
            AddForeignKey("dbo.SatisHarakets", "Personel_Personelid", "dbo.Personels", "Personelid");
            AddForeignKey("dbo.SatisHarakets", "Cariler_Cariid", "dbo.Carilers", "Cariid");
        }
    }
}

﻿namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Departman : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departmen", "Durum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departmen", "Durum");
        }
    }
}

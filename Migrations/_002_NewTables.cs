using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMigrator;

namespace OtobusBiletiUygulamasi.Migrations
{
    [Migration(2)]
    public class _002_NewTables : Migration
    {
        public override void Down()
        {
            Delete.Table("sofor");
            Delete.Table("muavin");
            Delete.Table("bus");
        }

        public override void Up()
        {
            Create.Table("sofor")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("SoforAd").AsString(45)
                .WithColumn("SoforSoyad").AsString(45)
                .WithColumn("SoforTC").AsString(45)
                .WithColumn("SoforNumara").AsString(45);
            //.WithColumn("IsFree").AsBoolean() // tinyint(1)

            Create.Table("muavin")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("MuavinAd").AsString(45)
                .WithColumn("MuavinSoyad").AsString(45)
                .WithColumn("MuavinTC").AsString(45)
                .WithColumn("MuavinNumara").AsString(45);
            //.WithColumn("IsFree").AsBoolean() // tinyint(1)

            Create.Table("bus")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("BusName").AsString(45)
                .WithColumn("BusLicense").AsString(45);
        }
        
    }
}

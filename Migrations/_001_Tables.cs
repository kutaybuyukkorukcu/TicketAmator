using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMigrator;

namespace OtobusBiletiUygulamasi.Migrations
{
    [Migration(1)]
    public class _001_Tables : Migration
    {
        public override void Down()
        {
            Delete.Table("bus_info");
            Delete.Table("sold_ticket");
            Delete.Table("users");
        }

        public override void Up()
        {
            Create.Table("bus_info")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("KalkisDest").AsString(45)
                .WithColumn("VarisDest").AsString(45)
                .WithColumn("KalkisTime").AsString(45)
                .WithColumn("VarisTime").AsString(45).Nullable()
                .WithColumn("KalkisDate").AsDate()
                .WithColumn("KoltukSayisi").AsInt32().Nullable()
                .WithColumn("Fiyat").AsInt32()
                .WithColumn("BusID").AsInt32().ForeignKey("bus", "ID").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("SoforID").AsInt32().ForeignKey("sofor", "ID").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("MuavinID").AsInt32().ForeignKey("muavin", "ID").OnDelete(System.Data.Rule.Cascade);

            Create.Table("sold_ticket")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("RouteID").AsInt32().ForeignKey("bus_info", "ID").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("YolcuAd").AsString(45)
                .WithColumn("YolcuSoyad").AsString(45).Nullable()
                .WithColumn("Telefon").AsString(45)
                .WithColumn("Email").AsString(45)
                .WithColumn("KoltukNo").AsInt32()
                .WithColumn("KimlikNo").AsString(45);

            Create.Table("users")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("Username").AsString(45)
                .WithColumn("Password").AsString(45);
        }
    }
}
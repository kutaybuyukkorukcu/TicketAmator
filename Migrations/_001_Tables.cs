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
                .WithColumn("BUS_ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("KalkisDest").AsString(45).Nullable()
                .WithColumn("VarisDest").AsString(45).Nullable()
                .WithColumn("KalkisTime").AsTime().Nullable()
                .WithColumn("VarisTime").AsTime().Nullable()
                .WithColumn("KalkisDate").AsDate().Nullable()
                .WithColumn("KoltukSayisi").AsInt32().Nullable()
                .WithColumn("Fiyat").AsString(45).Nullable();

            Create.Table("sold_ticket")
                .WithColumn("UserID").AsInt32().ForeignKey("users", "ID").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("BusID").AsInt32().ForeignKey("bus_info", "BusID").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("YolcuAd").AsString(45).Nullable()
                .WithColumn("YolcuSoyad").AsString(45).Nullable()
                .WithColumn("Telefon").AsString(45).Nullable()
                .WithColumn("Email").AsString(45).Nullable()
                .WithColumn("KoltukNo").AsInt32().Nullable();
            Create.Table("users")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("Username").AsString(45).Nullable()
                .WithColumn("Password").AsString(45).Nullable();
        }
    }
}
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtobusBiletiUygulamasi.Models
{
    public class BusInfo
    {
        public virtual int ID { get; set; }
        public virtual int BusID { get; set; }
        public virtual int SoforID { get; set; }
        public virtual int MuavinID { get; set; }

        public virtual string KalkisDest { get; set; }
        public virtual string VarisDest { get; set; }
        public virtual string KalkisTime { get; set; }
        public virtual string VarisTime { get; set; }
        public virtual DateTime? KalkisDate { get; set; }
        public virtual int KoltukSayisi { get; set; }
        public virtual int Fiyat { get; set; }

        // Delete them after pp
        public virtual string BusName { get; set; }
        public virtual string SoforAd { get; set; }
        public virtual string SoforSoyad { get; set; }
        public virtual string MuavinAd { get; set; }
        public virtual string MuavinSoyad { get; set; }
    }

    public class BusInfoMap : ClassMapping<BusInfo>
    {
        public BusInfoMap()
        {
            Table("bus_info");

            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.BusID, x => x.NotNullable(true));
            Property(x => x.SoforID, x => x.NotNullable(true));
            Property(x => x.MuavinID, x => x.NotNullable(true));

            Property(x => x.KalkisDest, x => x.NotNullable(true));
            Property(x => x.VarisDest, x => x.NotNullable(true));
            Property(x => x.KalkisTime, x => x.NotNullable(true));
            Property(x => x.VarisTime);
            Property(x => x.KalkisDate, x => x.NotNullable(true));
            Property(x => x.KoltukSayisi, x => x.NotNullable(true));
            Property(x => x.Fiyat);
        }
    }
}
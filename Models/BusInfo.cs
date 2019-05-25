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
        public virtual int BusID { get; set; }
        public virtual string KalkisDest { get; set; }
        public virtual string VarisDest { get; set; }
        public virtual TimeSpan? KalkisTime { get; set; }
        public virtual TimeSpan? VarisTime { get; set; }
        public virtual DateTime? KalkisDate { get; set; }
        public virtual int KoltukSayisi { get; set; }
        public virtual string Fiyat { get; set; }
    }

    public class BusInfoMap : ClassMapping<BusInfo>
    {
        public BusInfoMap()
        {
            Table("bus_info");

            Id(x => x.BusID, x => x.Generator(Generators.Identity));
            Property(x => x.KalkisDest);
            Property(x => x.VarisDest);
            Property(x => x.KalkisTime);
            Property(x => x.VarisTime);
            Property(x => x.KalkisDate);
            Property(x => x.KoltukSayisi);
            Property(x => x.Fiyat);
        }
    }
}
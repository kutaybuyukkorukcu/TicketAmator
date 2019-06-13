using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace OtobusBiletiUygulamasi.Models
{
    public class Sofor
    {

            public virtual int ID { get; set; }
            public virtual string SoforAd { get; set; }
            public virtual string SoforSoyad { get; set; }
            public virtual string SoforTC { get; set; }
            public virtual string SoforNumara { get; set; }
            // public virtual bool IsFree { get; set; }
    }

    public class SoforMap : ClassMapping<Sofor>
    {
        public SoforMap()
        {
            Table("sofor");

            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.SoforAd, x => x.NotNullable(true));
            Property(x => x.SoforSoyad, x => x.NotNullable(true));
            Property(x => x.SoforTC, x => x.NotNullable(true));
            Property(x => x.SoforNumara, x => x.NotNullable(true));
        }
    }
}

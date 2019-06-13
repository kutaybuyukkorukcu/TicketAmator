using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace OtobusBiletiUygulamasi.Models
{
    public class Muavin
    {

        public virtual int ID { get; set; }
        public virtual string MuavinAd { get; set; }
        public virtual string MuavinSoyad { get; set; }
        public virtual string MuavinTC { get; set; }
        public virtual string MuavinNumara { get; set; }
        // public virtual bool IsFree { get; set; }
    }

    public class MuavinMap : ClassMapping<Muavin>
    {
        public MuavinMap()
        {
            Table("muavin");

            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.MuavinAd, x => x.NotNullable(true));
            Property(x => x.MuavinSoyad, x => x.NotNullable(true));
            Property(x => x.MuavinTC, x => x.NotNullable(true));
            Property(x => x.MuavinNumara, x => x.NotNullable(true));
        }
    }
}
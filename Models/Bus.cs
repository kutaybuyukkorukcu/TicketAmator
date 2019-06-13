using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace OtobusBiletiUygulamasi.Models
{
    public class Bus
    {
        public virtual int ID { get; set; }
        public virtual string BusName { get; set; }
        public virtual string BusLicense { get; set; }
    }

    public class BusMap : ClassMapping<Bus>
    {
        public BusMap()
        {
            Table("bus");

            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.BusName, x => x.NotNullable(true));
            Property(x => x.BusLicense, x => x.NotNullable(true));
        }
    }
}
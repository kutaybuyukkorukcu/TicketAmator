using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtobusBiletiUygulamasi.Models
{
    public class SoldTicket
    {
        public virtual int ID { get; set; }
        public virtual int BusID { get; set; }
        public virtual string YolcuAd { get; set; }
        public virtual string YolcuSoyad { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Email { get; set; }
    }

    public class SoldTicketMap : ClassMapping<SoldTicket>
    {
        public SoldTicketMap()
        {
            Table("sold_ticket");

            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.BusID, x => x.NotNullable(true));
            Property(x => x.YolcuAd);
            Property(x => x.YolcuSoyad);
            Property(x => x.Telefon);
            Property(x => x.Email);
        }
    }
}
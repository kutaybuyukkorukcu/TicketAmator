using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtobusBiletiUygulamasi.Models
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", 13);
        }

        public virtual void setPassword(string pass)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(pass, 13);
        }

        public virtual bool CheckPassword(string pass)
        {
            return BCrypt.Net.BCrypt.Verify(pass, Password);
        }
    }


    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("users");

            Id(x => x.ID, x => x.Generator(Generators.Identity));
            Property(x => x.Username, x => x.NotNullable(true));
            Property(x => x.Password, x => x.NotNullable(true));
        }
    }
}
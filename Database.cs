using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using OtobusBiletiUygulamasi.Models;


namespace OtobusBiletiUygulamasi
{
    public static class Database
    {
        private static ISessionFactory _sessionFactory;
        private const string SessionKey = "OtobusBiletiUygulamasi.Database.SessionKey";

        public static ISession Session
        {
            get
            {
                return (ISession)HttpContext.Current.Items[SessionKey];
            }
        }

        public static void Configure()
        {
            var config = new Configuration();
            config.Configure();

            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<BusInfoMap>();
            mapper.AddMapping<SoldTicketMap>(); // KoltukNo sonradan ekledim. FYI

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            _sessionFactory = config.BuildSessionFactory();
        }

        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {

            var session = HttpContext.Current.Items[SessionKey] as ISession;

            if (session != null)
            {
                session.Close();
            }

            HttpContext.Current.Items.Remove(SessionKey); // This used to/might be SessionKey
        }
    }
}
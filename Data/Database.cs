using System;
using NHibernate;
using NHibernate.Cfg;
using Data.Mappings;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Data;
using Data.Domain;

namespace Data
{

    public static class Database
    {
        private static ISessionFactory SessionFactory
        {
            get
            {
                return Fluently.Configure()
                  .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString"))
                  )
                  .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Korisnik>())
                  // .ExposeConfiguration(BuildSchema)
                  .BuildSessionFactory();
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("TestNHibernate_fluent.db"))
                File.Delete("TestNHibernate_fluent.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }
    }
}

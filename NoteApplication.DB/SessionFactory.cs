using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.DB
{
    public class SessionFactory
    {
        
        public SessionFactory()
        {
            if (_sessionFactory is null)
            {
                _sessionFactory = BuildSessionFactory(_connectionString);
            }
        }

        public ISession GetSession() => _sessionFactory.OpenSession();

        private readonly ISessionFactory _sessionFactory;

        private ISessionFactory BuildSessionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                //.Mappings(m => m.FluentMappings.AddFromAssembly(typeof().Assembly))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(true, true);
                });
            return configuration.BuildSessionFactory();
        }

        private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ADMIN\\Desktop\\Phase II\\Databases\\NoteAppDb5.mdf;Integrated Security=True;Connect Timeout=30";
    }
}

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using TagsBuilder_API.DAO.Map;

namespace DAO.ConnectionFactory
{
    public class ConnectionFactory
    { 
        private static FluentConfiguration CreateSession(string connectionString, string sid)
        {
            return Fluently.Configure()
                .Database(OracleManagedDataClientConfiguration
                    .Oracle10
                    .ConnectionString(c => c.Is(connectionString))
                    .ShowSql().FormatSql()
                    .DefaultSchema(sid))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PcEmprMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CtrlPrgUsrMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PcProdutMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TagWatcherMap>());
        }

        public static ISessionFactory GetConnection(string connectionString, string sid)
        {
            return CreateSession(connectionString, sid).BuildSessionFactory();
        }
    }
}
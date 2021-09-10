using Microsoft.EntityFrameworkCore;
using RC.EntityFramework.Api.Core;
using RC.EntityFramework.Api.Core.Enum;

namespace RC.EntityFramework.Api.Infrastructure.Data.EntityFramework
{
    public class DBContextBase : DbContext
    {
        private readonly ConfigurationApplication configurationApplication;
        public DBContextBase(ConfigurationApplication configurationApplication) : base(new DbContextOptions<DBContextBase>())
        {
            this.configurationApplication = configurationApplication;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseLazyLoadingProxies();
            var connection = new DataConnectionFactory(this.configurationApplication).GetConnection();
            contextOptionsBuilder.UseSqlServer(connection, sql => sql.CommandTimeout(180))
                                 .EnableSensitiveDataLogging(this.configurationApplication.Ambient == (int)AmbientTypes.Development);
        }
    }
}
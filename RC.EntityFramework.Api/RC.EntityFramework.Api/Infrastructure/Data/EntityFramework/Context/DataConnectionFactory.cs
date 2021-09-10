using RC.EntityFramework.Api.Core;
using RC.EntityFramework.Api.Core.Enum;
using System;

namespace RC.EntityFramework.Api.Infrastructure.Data.EntityFramework
{
    public class DataConnectionFactory
    {
        private readonly ConfigurationApplication configurationApplication;

        public DataConnectionFactory(ConfigurationApplication configurationApplication)
        {
            this.configurationApplication = configurationApplication;
        }

        public string GetConnection()
        {
            try
            {
                return this.configurationApplication.Ambient == AmbientTypes.Development ?
                       this.configurationApplication.ConnectionDeveloper :
                       this.configurationApplication.ConnectionProduction;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
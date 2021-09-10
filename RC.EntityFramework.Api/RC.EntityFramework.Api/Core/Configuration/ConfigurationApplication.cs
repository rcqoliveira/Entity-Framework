using RC.EntityFramework.Api.Core.Enum;

namespace RC.EntityFramework.Api.Core
{
    public class ConfigurationApplication
    {
        public AmbientTypes Ambient { get; set; }
        public string ConnectionDeveloper { get; set; }
        public string ConnectionProduction { get; set; }
    }
}
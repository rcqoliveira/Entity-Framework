namespace RC.EntityFramework.Api.Infrastructure.Data.EntityFramework
{
    public class BaseConfiguration
    {
        protected string Schema { get; set; }

        public BaseConfiguration()
        {
            this.Schema = "DBO";
        }
        public BaseConfiguration(string schema)
        {
            this.Schema = schema;
        }
    }
}

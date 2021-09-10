namespace RC.EntityFramework.Api.Core.Domains.Entitie
{
    public class Product : BaseEntitie
    {
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}
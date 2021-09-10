using RC.EntityFramework.Api.Core;
using RC.EntityFramework.Api.Core.Domains.Entitie;
using RC.EntityFramework.Api.Core.Interface;
using RC.EntityFramework.Api.Infrastructure.Data.EntityFramework.Context;

namespace RC.EntityFramework.Api.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DBContextApplication context) : base(context)
        {

        }
    }
}
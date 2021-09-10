using RC.EntityFramework.Api.Core.AutoMapper;
using RC.EntityFramework.Api.Core.Domains.Entitie;
using RC.EntityFramework.Api.Core.Interface;
using RC.EntityFramework.Api.Core.Request;
using RC.EntityFramework.Api.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.EntityFramework.Api.Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task DeleteRowAsync(int id)
        {
            await this.productRepository.DeleteRowAsync(id);
        }
        
        public async Task<ProductResponse> GetAsync(int id)
        {
            var entity = await this.productRepository.GetAsync(id);
            return entity.MapTo<Product, ProductResponse>();
        }
        
        public async Task UpdateAsync(ProductUpdateRequest request)
        {
            var entity = request.MapTo<ProductUpdateRequest, Product>();
            await this.productRepository.UpdateAsync(entity);
        }
        
        public async Task InsertAsync(ProductInsertRequest request)
        {
            var entity = request.MapTo<ProductInsertRequest, Product>();
            await this.productRepository.InsertAsync(entity);
        }
        
        public async Task<IEnumerable<ProductResponse>> GetAllAsync(int pageSize, int pageActual)
        {
            var entities = await this.productRepository.GetAllAsync(pageSize, pageActual);

            return entities.MapTo<IEnumerable<Product>, IEnumerable<ProductResponse>>();
        }
    }
}
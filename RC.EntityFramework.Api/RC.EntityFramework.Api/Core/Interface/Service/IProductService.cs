using RC.EntityFramework.Api.Core.Request;
using RC.EntityFramework.Api.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.EntityFramework.Api.Core.Interface
{
    public interface IProductService
    {
        Task DeleteRowAsync(int id);
        Task<ProductResponse> GetAsync(int id);
        Task UpdateAsync(ProductUpdateRequest entity);
        Task InsertAsync(ProductInsertRequest entity);
        Task<IEnumerable<ProductResponse>> GetAllAsync(int pageSize, int pageActual);
    }
}
using AutoMapper;
using RC.EntityFramework.Api.Core.Domains.Entitie;
using RC.EntityFramework.Api.Core.Request;
using RC.EntityFramework.Api.Core.Response;

namespace RC.Dapper.Api.Core.AutoMapper
{
    public class ProductionProfile : Profile
    {
        public ProductionProfile()
        {
            CreateMap<Product, ProductInsertRequest>().ReverseMap();
            CreateMap<Product, ProductUpdateRequest>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}

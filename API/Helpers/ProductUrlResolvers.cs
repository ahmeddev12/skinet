using API.Dtos;
using AutoMapper;
using core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    /* her product is the source of mapping and producttoreturnDto is the destination and string is the return type*/
    public class ProductUrlResolvers : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolvers(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
           {
               return _config["ApiUrl"]+source.PictureUrl;
           }
           return null;
        }
    }
}
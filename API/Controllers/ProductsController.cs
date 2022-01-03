
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   /* [ApiController]
    [Route("api/[controller]")]*/
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public readonly IGenericRepository<Product> _ProductRepo ;

        // public IProductRepository _repo { get; }
        public ProductsController(IGenericRepository<Product> productRepo,IGenericRepository<ProductBrand> productBrandRepo
        ,IGenericRepository<ProductType> productTypeRepo,IMapper mapper/*IProductRepository repo*/)
        {
            _ProductRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
            //  _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {


            var spec=new ProductsWithTypesAndBrandsSpecification();
            //var products=await _repo.GetProductsAsync();
             var products=await _ProductRepo.ListAsync(spec);

           /* return products.Select(x=>new ProductToReturnDto{

                Id=x.Id,
               Name=x.Name,
               Description=x.Description,
               PictureUrl=x.PictureUrl,
               Price=x.Price,
               ProductBrand=x.ProductBrand.Name,
               ProductType=x.ProductType.Name

            }).ToList() ;*/
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {


           // return await _repo.GetProductByIdAsync(id);
            var spec=new ProductsWithTypesAndBrandsSpecification(id);
            //var products=await _repo.GetProductsAsync();
           var product= await _ProductRepo.GetEntityWithSpec(spec);
          /* return new ProductToReturnDto{

               Id=product.Id,
               Name=product.Name,
               Description=product.Description,
               PictureUrl=product.PictureUrl,
               Price=product.Price,
               ProductBrand=product.ProductBrand.Name,
               ProductType=product.ProductType.Name

           };*/
           if(product==null)
           return NotFound();
           return _mapper.Map<Product,ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
           // var productBrands=await _repo.GetProductBrandsAsync();
            var productBrands=await _productBrandRepo.LisAllAsync();
            return Ok(productBrands);
        }


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes=await _productTypeRepo.LisAllAsync();
           // var productTypes=await _repo.GetProductTypesAsync();

            return Ok(productTypes);
        }
    }
}
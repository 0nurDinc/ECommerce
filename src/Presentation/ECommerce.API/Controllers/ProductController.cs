using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductList()
        {
            var productList = await _unitOfWork.ProductRepository.GetAll();
            var resultList = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>> (productList);
            return Ok(resultList);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductListID(Guid ID)
        {
            var productList = await _unitOfWork.ProductRepository.GetByID(ID);
            var resultList = _mapper.Map<Product,ProductDTO>(productList);
            return Ok(resultList);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetFilterProductList([FromBody]FilterModel filterModel)
        {
            try
            {
                var filteredProducts = await _unitOfWork.ProductRepository.GetFilterAll(x => x.CategoryID == filterModel.CategoryID ||
                                                                                           x.ProductName == filterModel.ProductName ||
                                                                                           x.Price == filterModel.Price ||
                                                                                           x.Supplier == filterModel.Supplier);

                if(filteredProducts == null || !filteredProducts.Any())
                {
                    return NotFound();
                }

                var result = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>> (filteredProducts);
                return Ok(result);

            }
            catch (ECommerceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
    }
}

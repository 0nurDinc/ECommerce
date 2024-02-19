using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryList()
        {
            var categoryList = await _unitOfWork.CategoryRepository.GetAll();
            var resultList = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categoryList);
            return Ok(resultList);
        }


    }
}

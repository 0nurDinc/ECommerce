using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var customer = await unitOfWork.CustomerRepository.GetByID(id);
            if (customer is null)
                return NotFound();

            unitOfWork.CustomerRepository.DeleteEntity(customer,true);
            return NoContent();
        }  
    }
}

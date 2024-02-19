using ECommerce.API.Filters;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [StockControlFilter]
        public async Task<ActionResult> Order([FromBody] List<MyShoppingCard> myShoppingCard)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var orderID = Guid.NewGuid();
                var total = 0d;
                
                foreach (var card in myShoppingCard)
                {
                    _unitOfWork.OrderDetailRepository.AddEntity(new OrderDetail()
                    {
                        OrderID = orderID,
                        Unite = card.Unit,
                        ProductID = card.ProductID,
                        Price = (await _unitOfWork.ProductRepository.GetByID(card.ProductID)).Price,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    });

                    var product = await _unitOfWork.ProductRepository.GetByID(card.ProductID);
                    product.Stock -= card.Unit;
                    total += card.Unit * product.Price;

                    _unitOfWork.ProductRepository.UpdateEntity(product);
                }

                _unitOfWork.OrderRepository.AddEntity(new Order()
                {
                    ID = Guid.NewGuid(),
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    CreatorID = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    Discount=0,
                    OrderDate=DateTime.Now,
                    Price = total,
                    FinalPrice = total,
                });


                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
            }
            

            return Ok();
        }
        
    }
}

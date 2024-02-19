using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using System.Net;

namespace ECommerce.API.Filters
{
    public class StockControlFilterAttribute:ActionFilterAttribute
    {
        

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var serviceProvider = context.HttpContext.RequestServices;
            var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

            if (context.ActionArguments.ContainsKey("myShoppingCard"))
            {
                var myShoppingCard = (List<MyShoppingCard>)context.ActionArguments["myShoppingCard"];

                foreach (var item in myShoppingCard)
                {
                    bool isAvailable = (await unitOfWork.ProductRepository.GetByID(item.ProductID)).Stock > item.Unit;

                    if (!isAvailable)
                    {
                        context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(
                            $"Stokta yeterli ürün bulunmamaktadır. (ProductID: {item.ProductID})")
                        {
                            StatusCode = (int)HttpStatusCode.BadRequest
                        };
                        return;
                    }
                }
            }

            await next();
        }
    }
}

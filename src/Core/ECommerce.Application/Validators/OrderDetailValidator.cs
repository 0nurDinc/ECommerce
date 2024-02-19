using ECommerce.Application.DTOs;
using ECommerce.Application.Validators.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators
{
    public class OrderDetailValidator:BaseValidator<OrderDetailDTO>
    {
        public OrderDetailValidator()
        {
            RuleFor(x => x.OrderID)
                .NotNull().WithMessage("Order ID field cannot be null.")
                .NotEmpty().WithMessage("Order ID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Order ID field cannot be Guid.Empty.");

            RuleFor(x => x.ProductID)
                .NotNull().WithMessage("Product ID field cannot be null.")
                .NotEmpty().WithMessage("Product ID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Product ID field cannot be Guid.Empty.");

            RuleFor(x => x.Unite)
                .NotNull().WithMessage("Unit field cannot be null.")
                .NotEmpty().WithMessage("Unit field cannot be empty.");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price field cannot be null.")
                .NotEmpty().WithMessage("Price field cannot be empty.")
                .LessThan(0).WithMessage("Price field must be greater than or equal to 0.");

        }
    }
}

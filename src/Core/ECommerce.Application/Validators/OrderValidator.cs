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
    public class OrderValidator:BaseValidator<OrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price field cannot be null.")
                .NotEmpty().WithMessage("Price field cannot be empty.")
                .LessThan(0).WithMessage("Price field must be greater than or equal to 0.");

            RuleFor(x => x.Discount)
                .NotEmpty().WithMessage("Discount field cannot be empty.")
                .LessThan(0).WithMessage("Discount field must be greater than or equal to 0.");

            RuleFor(x => x.FinalPrice)
                .NotNull().WithMessage("Final Price field cannot be null.")
                .NotEmpty().WithMessage("Final Price field cannot be empty.")
                .LessThan(0).WithMessage("Final Price field must be greater than or equal to 0.");

            RuleFor(x => x.OrderDate)
                .NotNull().WithMessage("Order Date field cannot be null.")
                .NotEmpty().WithMessage("Order Date field cannot be empty.");
        }
    }
}

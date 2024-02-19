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
    public class InvoiceValidator:BaseValidator<InvoiceDTO>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.OrderID)
               .NotNull().WithMessage("Order ID field cannot be null.")
               .NotEmpty().WithMessage("Order ID field cannot be empty.")
               .NotEqual(Guid.Empty).WithMessage("Order ID field cannot be Guid.Empty.");

            RuleFor(x => x.CustomerID)
                .NotNull().WithMessage("Customer ID field cannot be null.")
                .NotEmpty().WithMessage("Customer ID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Customer ID field cannot be Guid.Empty.");

            RuleFor(x => x.IsEmployee)
                .NotNull().WithMessage("IsEmployee field cannot be null.");

            RuleFor(x => x.InvoiceDate)
                .NotNull().WithMessage("Invoice Date field cannot be null.")
                .NotEmpty().WithMessage("Invoice Date field cannot be empty.");

            RuleFor(x => x.InvoiceAddress)
                .NotNull().WithMessage("Invoice Address field cannot be null.")
                .NotEmpty().WithMessage("Invoice Address field cannot be empty.")
                .MaximumLength(1000).WithMessage("Invoice Address field cannot exceed 1000 characters.");
        }
    }
}

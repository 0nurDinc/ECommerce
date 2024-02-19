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
    public class CustomerLoginValidator:BaseValidator<CustomerLoginDTO>
    {
        public CustomerLoginValidator()
        {
            RuleFor(x => x.CustomerID)
                .NotNull().WithMessage("Customer ID field cannot be null.")
                .NotEmpty().WithMessage("Customer ID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Customer ID field cannot be Guid.Empty.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password field cannot be null.")
                .NotEmpty().WithMessage("Password field cannot be empty.");

            RuleFor(x => x.Salt)
                .NotNull().WithMessage("Salt field cannot be null.")
                .NotEmpty().WithMessage("Salt field cannot be empty.");


        }
    }
}

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
    public class EmployeeLoginValidator:BaseValidator<EmployeeLoginDTO>
    {
        public EmployeeLoginValidator()
        {
            RuleFor(x => x.EmployeeID)
               .NotNull().WithMessage("Employee ID field cannot be null.")
               .NotEmpty().WithMessage("Employee ID field cannot be empty.")
               .NotEqual(Guid.Empty).WithMessage("Employee ID field cannot be Guid.Empty.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password field cannot be null.")
                .NotEmpty().WithMessage("Password field cannot be empty.");

            RuleFor(x => x.Salt)
                .NotNull().WithMessage("Salt field cannot be null.")
                .NotEmpty().WithMessage("Salt field cannot be empty.");

            RuleFor(x => x.RoleID)
                .NotNull().WithMessage("Role ID field cannot be null.")
                .NotEmpty().WithMessage("Role ID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Role ID field cannot be Guid.Empty.");

        }
    }
}

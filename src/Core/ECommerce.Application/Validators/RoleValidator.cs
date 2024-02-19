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
    public class RoleValidator:BaseValidator<RoleDTO>
    {
        public RoleValidator()
        {
            RuleFor(x => x.RoleType)
               .NotNull().WithMessage("Role Type field cannot be null.")
               .NotEmpty().WithMessage("Role Type field cannot be empty.");
        }
    }
}

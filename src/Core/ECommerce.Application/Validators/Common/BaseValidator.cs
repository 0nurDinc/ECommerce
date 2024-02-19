using ECommerce.Application.DTOs.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators.Common
{
    public class BaseValidator<T> :AbstractValidator<T> where T :BaseDTO
    {
        public BaseValidator()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID field cannot be null.")
                .NotEmpty().WithMessage("ID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("ID field cannot be Guid.Empty.");


            RuleFor(x => x.CreatorID)
                .NotNull().WithMessage("CreatorID field cannot be null.")
                .NotEmpty().WithMessage("CreatorID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("CreatorID field cannot be Guid.Empty.");


            RuleFor(x => x.CreatedDate)
                .NotNull().WithMessage("CreatedDate field cannot be null.")
                .NotEmpty().WithMessage("CreatedDate field cannot be empty.");


            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive field cannot be null.");

            RuleFor(x => x.ModifierID)
                .NotNull().WithMessage("ModifierID field cannot be null.")
                .NotEmpty().WithMessage("ModifierID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("ModifierID field cannot be Guid.Empty.");


            RuleFor(x => x.ModifiedDate)
                .NotEmpty().WithMessage("ModifiedDate field cannot be empty.");
        }
    }
}

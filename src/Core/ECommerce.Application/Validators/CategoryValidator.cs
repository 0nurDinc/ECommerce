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
    public class CategoryValidator:BaseValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotNull().WithMessage("CategoryName field cannot be null.")
                .NotEmpty().WithMessage("CategoryName field cannot be empty.")
                .MinimumLength(5).WithMessage("CategoryName field must be at least 5 characters long.")
                .MaximumLength(500).WithMessage("CategoryName field cannot exceed 500 characters.");

            RuleFor(x => x.CategoryDescription)
                .NotEmpty().WithMessage("CategoryDescription field cannot be empty.");

            RuleFor(x => x.CategoryPicturePath)
                .NotEmpty().WithMessage("CategoryPicturePath field cannot be empty.");

            RuleFor(x => x.ParentCategoryID)
                .NotNull().WithMessage("ParentCategoryID field cannot be null.")
                .NotEmpty().WithMessage("ParentCategoryID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("ParentCategoryID field cannot be Guid.Empty.");
        }
    }
}

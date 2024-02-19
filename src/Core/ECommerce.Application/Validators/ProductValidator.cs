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
    public class ProductValidator:BaseValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotNull().WithMessage("Product Name field cannot be null.")
                .NotEmpty().WithMessage("Product Name field cannot be empty.")
                .MinimumLength(3).WithMessage("Product Name field must be at least 3 characters long.")
                .MaximumLength(200).WithMessage("Product Name field cannot exceed 200 characters.");

            RuleFor(x => x.CategoryID)
                .NotNull().WithMessage("Category ID field cannot be null.")
                .NotEmpty().WithMessage("Category ID field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Category ID field cannot be Guid.Empty.");

            RuleFor(x => x.ProductDescription)
                .NotNull().WithMessage("Product Description field cannot be null.")
                .NotEmpty().WithMessage("Product Description field cannot be empty.")
                .MinimumLength(3).WithMessage("Product Description field must be at least 3 characters long.")
                .MaximumLength(800).WithMessage("Product Description field cannot exceed 800 characters.");

            RuleFor(x => x.ProductPicture)
                .NotNull().WithMessage("Product Picture field cannot be null.")
                .NotEmpty().WithMessage("Product Picture field cannot be empty.");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price field cannot be null.")
                .Must(p => p>0).WithMessage("Price field must be greater than or equal to 0.");

            RuleFor(x => x.Unit)
                .NotNull().WithMessage("Unit field cannot be null.");

            RuleFor(x => x.Stock)
                .NotNull().WithMessage("Stock field cannot be null.");

            RuleFor(x => x.Supplier)
                .NotNull().WithMessage("Supplier field cannot be null.")
                .NotEmpty().WithMessage("Supplier field cannot be empty.")
                .MinimumLength(3).WithMessage("Supplier field must be at least 3 characters long.")
                .MaximumLength(150).WithMessage("Supplier field cannot exceed 150 characters.");
        }
    }
}

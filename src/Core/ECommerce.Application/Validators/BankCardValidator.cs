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
    public class BankCardValidator:BaseValidator<BankCardDTO>
    {
        public BankCardValidator()
        {
            RuleFor(x => x.CardOwner)
                .NotNull().WithMessage("CardOwner field cannot be null.")
                .NotEmpty().WithMessage("CardOwner field cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("CardOwner field cannot be Guid.Empty.");

            RuleFor(x => x.CardNumber)
                .NotNull().WithMessage("CardNumber field cannot be null.")
                .NotEmpty().WithMessage("CardNumber field cannot be empty.")
                .Length(16).WithMessage("CardNumber field must be 16 characters long.")
                .Must(DigitControl).WithMessage("CardNumber field must contain only digits.");

            RuleFor(x => x.ExpirationDate)
                .NotNull().WithMessage("ExpirationDate field cannot be null.")
                .NotEmpty().WithMessage("ExpirationDate field cannot be empty.");

        }

        private bool DigitControl(string carNumber)
        {
            return carNumber.All(Char.IsDigit);
        }
    }
}

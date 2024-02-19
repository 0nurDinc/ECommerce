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
    public class CustomerValidator:BaseValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName)
               .NotNull().WithMessage("First Name field cannot be null.")
               .NotEmpty().WithMessage("First Name field cannot be empty.")
               .MaximumLength(60).WithMessage("First Name field cannot exceed 60 characters.")
               .MinimumLength(3).WithMessage("First Name field must be at least 3 characters long.");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Last Name field cannot be null.")
                .NotEmpty().WithMessage("Last Name field cannot be empty.")
                .MaximumLength(60).WithMessage("Last Name field cannot exceed 60 characters.")
                .MinimumLength(3).WithMessage("Last Name field must be at least 3 characters long.");

            RuleFor(x => x.PhoneNumber)
                .Must(TurkeyPhoneNumber).WithMessage("Invalid phone number format for Turkey.");

            RuleFor(x => x.EmailAddress)
                .NotNull().WithMessage("Email Address field cannot be null.")
                .NotEmpty().WithMessage("Email Address field cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address format.")
                .MinimumLength(11).WithMessage("Email Address field must be at least 11 characters long.")
                .MaximumLength(150).WithMessage("Email Address field cannot exceed 150 characters.");

            RuleFor(x => x.BirthOfDate)
                .NotNull().WithMessage("Birth Of Date field cannot be null.")
                .NotEmpty().WithMessage("Birth Of Date field cannot be empty.")
                .Must(AgeControl).WithMessage("Customer must be at least 18 years old.");

        }

        private bool TurkeyPhoneNumber(string phone)
        {
            if (phone is null)
                return false;

            return phone.Length.Equals(11) && phone.All(Char.IsDigit) && phone[0].Equals('0');
        }

        private bool AgeControl(DateTime dateTime)
        {
            TimeSpan timeDifference = DateTime.Now - dateTime;
            if (timeDifference.TotalDays > 18 * 365)
                return true;
            else
                return false;
        }
    }

}

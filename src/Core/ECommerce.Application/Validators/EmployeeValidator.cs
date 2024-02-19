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
    public class EmployeeValidator:BaseValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("First Name field cannot be null.")
                .NotEmpty().WithMessage("First Name field cannot be empty.")
                .MinimumLength(3).WithMessage("First Name field must be at least 3 characters long.")
                .MaximumLength(60).WithMessage("First Name field cannot exceed 60 characters.");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Last Name field cannot be null.")
                .NotEmpty().WithMessage("Last Name field cannot be empty.")
                .MinimumLength(3).WithMessage("Last Name field must be at least 3 characters long.")
                .MaximumLength(60).WithMessage("Last Name field cannot exceed 60 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("Phone Number field cannot be null.")
                .NotEmpty().WithMessage("Phone Number field cannot be empty.")
                .Must(phone =>
                {
                    return phone.Length.Equals(11) && phone[0].Equals('0') && phone.All(char.IsDigit);
                }).WithMessage("Invalid phone number format for Turkey.");

            RuleFor(x => x.EmailAddress)
                .NotNull().WithMessage("Email Address field cannot be null.")
                .NotEmpty().WithMessage("Email Address field cannot be empty.")
                .MinimumLength(15).WithMessage("Email Address field must be at least 15 characters long.")
                .MaximumLength(150).WithMessage("Email Address field cannot exceed 150 characters.");

            RuleFor(x => x.BirthOfDate)
                .Must(birthdate =>
                {
                    TimeSpan timeSpan = DateTime.Now - birthdate;
                    return timeSpan.TotalDays > 18 * 365;
                }).WithMessage("Employee must be at least 18 years old.");

        }
    }
}

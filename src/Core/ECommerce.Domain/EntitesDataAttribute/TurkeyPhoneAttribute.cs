using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.EntitesDataAttribute
{
    public class TurkeyPhoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;

            var phone = Convert.ToString(value);

            if (string.IsNullOrEmpty(phone))
                return false;

            return (phone.Length == 11 && phone.All(Char.IsDigit) && phone[0] == '0');
        }
    }
}

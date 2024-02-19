using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class BankCardDTO:BaseDTO
    {
        public Guid CardOwner { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ushort CVV { get; set; }

    }
}

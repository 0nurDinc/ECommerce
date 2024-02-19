using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public double Price { get; set; }
        public float? Discount { get; set; }
        public double FinalPrice { get; set; }
        public DateTime OrderDate { get; set; }

    }
}

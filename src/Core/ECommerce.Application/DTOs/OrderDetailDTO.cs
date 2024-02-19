using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class OrderDetailDTO:BaseDTO
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public uint Unite { get; set; }
        public double Price { get; set; }

    }
}

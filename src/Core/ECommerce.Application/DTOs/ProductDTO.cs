using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class ProductDTO:BaseDTO
    {
        public string ProductName { get; set; }
        public Guid CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPicture { get; set; }
        public double Price { get; set; }
        public sbyte Unit { get; set; }
        public uint Stock { get; set; }
        public string Supplier { get; set; }

    }
}

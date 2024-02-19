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
    public class InvoiceDTO:BaseDTO
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public bool IsEmployee { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceAddress { get; set; }

    }
}

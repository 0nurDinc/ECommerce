using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels
{
    public class FilterModel
    {

        public string ProductName { get; set; }
        public Guid CategoryID { get; set; }
        public double Price { get; set; }
        public sbyte Unit { get; set; }
        public string Supplier { get; set; }
    }
}

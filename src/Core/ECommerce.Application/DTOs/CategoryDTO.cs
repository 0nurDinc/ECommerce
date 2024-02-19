using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class CategoryDTO:BaseDTO
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryPicturePath { get; set; }
        public Guid ParentCategoryID { get; set; }

    }
}

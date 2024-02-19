using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order:BaseEntity
    {
        [Display(Name ="Price")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public double Price { get; set; }


        [Display(Name ="Discount")]
        public float? Discount { get; set; }


        [Display(Name ="Final Price")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public double FinalPrice { get; set; }


        [Display(Name ="Order Date")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public DateTime OrderDate { get; set; }



        public virtual IQueryable<OrderDetail> OrderDetails { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}

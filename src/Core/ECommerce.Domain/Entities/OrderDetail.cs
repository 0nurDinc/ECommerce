using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class OrderDetail:BaseEntity
    {
        [Display(Name ="Order ID")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [ForeignKey("Order")]
        public Guid OrderID { get; set; }



        [Display(Name ="Product ID")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }



        [Display(Name ="Unite")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public uint Unite { get; set; }



        [Display(Name ="Price")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public double Price { get; set; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

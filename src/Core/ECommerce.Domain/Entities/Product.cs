using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product:BaseEntity
    {
        [Display(Name ="Product Name")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(200,MinimumLength =3,ErrorMessage = "The product name cannot be less than 3 characters and cannot exceed 200 characters.")]
        public string ProductName { get; set; }


        [Display(Name ="Category")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public Guid CategoryID { get; set; }


        [Display(Name ="Description")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(800,MinimumLength =3,ErrorMessage = "Product description cannot be less than 3 characters and cannot exceed 800 characters.")]
        public string ProductDescription { get; set; }


        [Display(Name ="Product Image")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public string ProductPicture { get; set; }

        
        [Display(Name ="Price")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public double Price { get; set; }


        [Display(Name ="Unit")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public sbyte Unit { get; set; }


        [Display(Name ="Stock")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public uint Stock { get; set; }


        [Display(Name ="Supplier")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(maximumLength:150,MinimumLength =3,ErrorMessage = "Product supplier name can be a minimum of 3 and a maximum of 150 characters.")]
        public string Supplier { get; set; }


        public virtual Category Category { get; set; }
        public virtual IQueryable<OrderDetail> OrderDetails { get; set; }
    }
}

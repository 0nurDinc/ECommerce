using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Category:BaseEntity
    {
        [Display(Name ="Category")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(maximumLength: 500,MinimumLength = 5,ErrorMessage = "The category name cannot be less than 5 characters and more than 500 characters.")]
        public string CategoryName { get; set; }


        [Display(Name ="Description")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public string CategoryDescription { get; set; }


        [Display(Name ="Picture")]
        public string CategoryPicturePath { get; set; }


        [Display(Name ="Parent Category")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public Guid ParentCategoryID { get; set; }


        public virtual IQueryable<Product> Products { get; set; }
    }
}

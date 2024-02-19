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
    public class Invoice:BaseEntity
    {
        [Display(Name ="Order")]
        [ForeignKey("Order")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public Guid OrderID { get; set; }

        [ForeignKey("Customer")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public Guid CustomerID { get; set; }


        [Display(Name ="Is Employee")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public bool IsEmployee { get; set; }


        [Display(Name ="Invoice Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yyyy}")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public DateTime InvoiceDate { get; set; }


        [Display(Name ="Invoice Address")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [MaxLength(1000,ErrorMessage = "The billing address cannot exceed 1000 characters.")]
        public string InvoiceAddress { get; set; }


        public virtual Order Order { get; set; }
        public virtual CustomerLogin Customer { get; set; }
    }
}

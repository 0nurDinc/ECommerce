using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class BankCard:BaseEntity
    {
        [Display(Name ="Card Owner")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public Guid CardOwner { get; set; }

        [Display(Name ="Card Number")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(16,MinimumLength =16,ErrorMessage = "The card number will be 16 digits.")]
        public string CardNumber { get; set; }

        [Display(Name ="Expiration Date")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:MM/yyyy}")]
        public DateTime ExpirationDate { get; set; }


        [Display(Name ="CVV")]
        [Range(100,999,ErrorMessage = "An invalid cvv value.")]
        public ushort CVV { get; set; }

        public virtual EmployeeLogin EmployeeLogin { get; set; }
        public virtual CustomerLogin CustomerLogin { get; set; }
    }
}

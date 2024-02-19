using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public Guid ID { get; set; }


        [Display(Name ="Creator")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public Guid CreatorID { get; set; }


        [Display(Name ="Modifier")]
        public Guid? ModifierID { get; set; }


        [Display(Name ="Created Date")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public DateTime CreatedDate { get; set; }


        [Display(Name ="Modified Date")]
        public DateTime? ModifiedDate { get; set; }


        [Display(Name ="Is Active")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public bool IsActive { get; set; }

    }
}

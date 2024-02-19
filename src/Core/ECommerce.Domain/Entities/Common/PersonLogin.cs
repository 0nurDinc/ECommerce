using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Common
{
    public abstract class PersonLogin:BaseEntity
    {
        [Display(Name = "Person")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [ForeignKey("Person")]
        public Guid PersonID { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public byte[] Password { get; set; }


        [Display(Name = "Salt")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public byte[] Salt { get; set; }
    }
}

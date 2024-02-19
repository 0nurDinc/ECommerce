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
    public class EmployeeLogin:PersonLogin
    {
        
        [Display(Name ="Employee Role")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [ForeignKey("Role")]
        public Guid RoleID { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }

        public virtual BankCard BankCard{ get; set; }

    }
}

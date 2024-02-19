using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Role:BaseEntity
    {
        [Display(Name ="Role Type")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        public string RoleType { get; set; }

        public virtual IQueryable<EmployeeLogin> EmployeeLogins { get; set; }   
    }
}

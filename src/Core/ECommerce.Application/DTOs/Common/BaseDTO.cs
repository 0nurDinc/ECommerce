using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Common
{
    public abstract class BaseDTO
    {
        [Key]
        public Guid ID { get; set; }
        public Guid CreatorID { get; set; }
        public Guid? ModifierID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

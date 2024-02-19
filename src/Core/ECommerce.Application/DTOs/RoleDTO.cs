using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class RoleDTO:BaseDTO
    {
        public string RoleType { get; set; }
    }
}

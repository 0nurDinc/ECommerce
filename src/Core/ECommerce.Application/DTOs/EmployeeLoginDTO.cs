using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class EmployeeLoginDTO:BaseDTO
    {
        public Guid EmployeeID { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public Guid RoleID { get; set; }

    }
}

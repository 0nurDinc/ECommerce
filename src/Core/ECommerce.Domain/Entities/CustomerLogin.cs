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
    public class CustomerLogin : PersonLogin
    {
        public virtual Customer Customer { get; set; }
        public virtual IQueryable<BankCard> BankCards { get; set; }
        public virtual IQueryable<Invoice> Invoices { get; set; }
    }
}

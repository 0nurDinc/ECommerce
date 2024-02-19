using ECommerce.Application.Interfaces.Repository.Common;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Repository
{
    public interface ICustomerLoginRepository:IBaseRepository<CustomerLogin>
    {
    }
}

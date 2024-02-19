using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repository
{
    public class CustomerLoginRepository : BaseRepository<CustomerLogin>, ICustomerLoginRepository
    {
        public CustomerLoginRepository(DbContext context) : base(context)
        {
        }
    }
}

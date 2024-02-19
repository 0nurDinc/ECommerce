using ECommerce.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBankCardRepository BankCardRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICustomerLoginRepository CustomerLoginRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IEmployeeLoginRepository EmployeeLoginRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IOrderDetailRepository  OrderDetailRepository { get; }
        IRoleRepository RoleRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }


        void BeginTransaction();
        void Commit();
        void Rollback();

    }
}

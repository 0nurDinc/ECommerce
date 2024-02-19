using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBankCardRepository BankCardRepository{get;}

        public ICategoryRepository CategoryRepository{get;}

        public ICustomerLoginRepository CustomerLoginRepository{get;}

        public ICustomerRepository CustomerRepository{get;}

        public IEmployeeLoginRepository EmployeeLoginRepository{get;}

        public IEmployeeRepository EmployeeRepository{get;}

        public IInvoiceRepository InvoiceRepository{get;}

        public IOrderDetailRepository OrderDetailRepository{get;}

        public IRoleRepository RoleRepository{get;}

        public IProductRepository ProductRepository{get;}

        public IOrderRepository OrderRepository{get;}


        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
            BankCardRepository = new BankCardRepository(context);
            CategoryRepository = new CategoryRepository(context);
            CustomerLoginRepository = new CustomerLoginRepository(context); 
            CustomerRepository = new CustomerRepository(context);
            EmployeeLoginRepository = new EmployeeLoginRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
            InvoiceRepository = new InvoiceRepository(context);
            RoleRepository = new RoleRepository(context);
            ProductRepository = new ProductRepository(context);
            OrderRepository = new OrderRepository(context);
            RoleRepository = new RoleRepository(context);

        }

        public UnitOfWork()
        {
        }

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public void Commit()
        {
            context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            context.Database.RollbackTransaction();
        }

        public async ValueTask DisposeAsync()
        {
            context.Dispose();
            await Task.CompletedTask;
        }

    }
}

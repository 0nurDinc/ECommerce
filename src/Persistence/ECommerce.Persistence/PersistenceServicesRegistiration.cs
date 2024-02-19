using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Persistence.Repository;
using ECommerce.Persistence.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public static class PersistenceServicesRegistiration
    {
        public static void AddPersistenceServiceRegistiration(this IServiceCollection services,IConfiguration configuration = null)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IBankCardRepository, BankCardRepository>();
            services.AddTransient<ICategoryRepository,CategoryRepository>();
            services.AddTransient<ICustomerLoginRepository, CustomerLoginRepository>();
            services.AddTransient<ICustomerRepository,CustomerRepository>();
            services.AddTransient<IEmployeeLoginRepository, EmployeeLoginRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>(); 
            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository,RoleRepository>();
        }
    }
}

 
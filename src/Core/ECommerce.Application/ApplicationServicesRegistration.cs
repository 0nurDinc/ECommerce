using ECommerce.Application.DTOs;
using ECommerce.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void AddApplicationServiceRegistiration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServicesRegistration));

            services.AddTransient<IValidator<BankCardDTO>, BankCardValidator>();
            services.AddTransient<IValidator<CategoryDTO>,CategoryValidator>();
            services.AddTransient<IValidator<CustomerLoginDTO>, CustomerLoginValidator>();
            services.AddTransient<IValidator<CustomerDTO>, CustomerValidator>();  
            services.AddTransient<IValidator<EmployeeLoginDTO>, EmployeeLoginValidator>();
            services.AddTransient<IValidator<EmployeeDTO>, EmployeeValidator>();
            services.AddTransient<IValidator<InvoiceDTO>,InvoiceValidator>();
            services.AddTransient<IValidator<OrderDetailDTO>, OrderDetailValidator>();
            services.AddTransient<IValidator<OrderDTO>, OrderValidator>();
            services.AddTransient<IValidator<ProductDTO>, ProductValidator>();
            services.AddTransient<IValidator<RoleDTO>, RoleValidator>();


        }
    }
}


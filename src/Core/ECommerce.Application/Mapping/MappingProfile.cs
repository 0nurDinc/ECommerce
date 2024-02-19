using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BankCardDTO, BankCard>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<CustomerLoginDTO, CustomerLogin>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<EmployeeLoginDTO, EmployeeLogin>().ReverseMap();
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

        }
    }
}

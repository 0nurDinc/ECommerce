﻿using ECommerce.Domain.EntitesDataAttribute;
using ECommerce.Domain.EntitesException;
using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Employee:Person
    {
        public virtual EmployeeLogin EmployeeLogin { get; set; }

    }
}

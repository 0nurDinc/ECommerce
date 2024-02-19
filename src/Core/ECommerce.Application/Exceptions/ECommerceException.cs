using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Application.Exceptions
{
    public class ECommerceException:Exception
    {
        public ECommerceException():base()
        {
            
        }

        public ECommerceException(string message):base(message)
        {
            
        }


        public ECommerceException(string message, Exception innerException):base(message,innerException)
        {
            
        }

    }
}

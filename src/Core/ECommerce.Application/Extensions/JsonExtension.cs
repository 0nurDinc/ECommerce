using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Extensions
{
    public static class JsonExtension
    {
        public static string SerializeToJson<T>(this T obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeFromJson<T>(this string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException(nameof(json));

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

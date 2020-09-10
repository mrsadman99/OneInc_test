using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace OneInc_test.Web.Converters
{
    public static class Serializer
    {

        public static StringContent ToStringContent<T>(T instance)
        {
            return new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json");
        }

        public static string SerializeDateTime(DateTime? time) {
            return JsonConvert.SerializeObject(time,
                new IsoDateTimeConverter() { 
                    DateTimeFormat = "yyyy-MM-dd" });
        }

    }
}
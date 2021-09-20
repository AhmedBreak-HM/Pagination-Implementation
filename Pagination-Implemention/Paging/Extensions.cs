using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination_Implemention.Paging
{
    public static class Extensions
    {
        public static void AddPaginationHeader(this HttpResponse response , PaginationHeaderParams @params)
        {
            // Convert Obj To string and CamleCase
            var camlcaseFormatter = new JsonSerializerSettings();
            camlcaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var paginationToString = JsonConvert.SerializeObject(@params, camlcaseFormatter);
            // -------------------------------------------------------------------------------

            // Add Header
            response.Headers.Add("Pagination-Header", paginationToString);
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination-Header");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

        }
    }
}

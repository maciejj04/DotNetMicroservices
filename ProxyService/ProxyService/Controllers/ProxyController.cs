using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProxyService.Controllers
{
    public class ProxyController : Controller
    {
        [Route("api/{*url}")]
        public IHeaderDictionary Get()
        {
            RequestHandler requestHandler = new RequestHandler(Request);
            using(var httpClient = new HttpClient()){
                // TODO: Get/Post etc. async!
            }

            return Request.Headers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProxyService.Controllers
{
    public class RequestHandler
    {
        private HttpRequest request{get;set;}
        public RequestHandler(HttpRequest request){
            this.request = request;
        }

        private Boolean validateRequestHeaders(){
            return false;
        }
    }
}

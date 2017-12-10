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
            //Request.Method
            //Request.Path
            //Request.Body - in case of post
            //Request.ContentLength
            //Request.ContentType
            
            return false;
        }
    }
}

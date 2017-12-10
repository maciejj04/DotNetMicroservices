using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProxyService.Controllers
{
    public class ProxyController : Controller
    {
        string upstreamServicerUrl = "http://localhost:5000";
        [Route("api/{*url}")]
        public string Get()
        {
            RequestHandler requestHandler = new RequestHandler(Request);
            MonitorRequest monitorRequest = new MonitorRequest(Request.Path, DateTime.Now, Type.REQUEST);
            monitorRequest.send();
            // TODO: Add headers
            //           -> pass to Monitor
            //           -> pass to BusinessService: wait for response and then:
            //                  -> pass to Monitor with same headers. 
            using(var httpClient = new HttpClient()){

                // TODO: no need to copy body when GET;
                var memStream = new System.IO.MemoryStream();
                Request.Body.CopyTo(memStream);
                
                memStream.Position = 0;
                string text;
                using (StreamReader reader = new StreamReader(memStream))
                {
                    text = reader.ReadToEnd();
                }
                Task<HttpResponseMessage> result;
                switch(Request.Method){
                    case "GET":
                        result = httpClient.GetAsync(upstreamServicerUrl + Request.Path);
                        break;
                    case "POST":
                        result = httpClient.PostAsync(upstreamServicerUrl + Request.Path,
                                new StringContent(text, Encoding.UTF8, "application/json")
                        );
                        break;
                    default:
                        throw new Exception("Not supported Request type!");
                }
                string res = result.Result.Content.ReadAsStringAsync().Result;
                monitorRequest.withDateTime(DateTime.Now).withType(Type.RESPONSE).send();
                return res;
            }

            
        }
    }
}

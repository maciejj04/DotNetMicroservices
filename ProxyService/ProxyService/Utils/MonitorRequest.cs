using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProxyService.Controllers
{
    public enum Type{
        REQUEST,
        RESPONSE
    }
    public class MonitorRequest
    {

        private HttpRequest request{get;set;}
        private HttpClient client{get;set;}
        MonitorRequestBody body;
        DateTime dateTime;
        Type type;
        // TODO: change URL from ext configuration(according to 12-factor rule)
        private const string requestUri = "http://localhost:5002/api/monitor/handleRequest";
        PathString requestPath;
        public MonitorRequest(PathString requestPath, DateTime dateTime, Type type){
            this.client = new HttpClient();
            this.dateTime = dateTime;
            this.type = type;
            this.requestPath = requestPath;
            this.body = new MonitorRequestBody(dateTime, requestPath, type);
            client.DefaultRequestHeaders.Add("TraceId", new Random().Next().ToString());
        }
        public MonitorRequest withDateTime(DateTime dateTime){
            this.dateTime = dateTime;
            this.updateBody();
            return this;
        }
        public MonitorRequest withType(Type type){
            this.type = type;
            this.updateBody();
            return this;
        }
        private void updateBody(){
            this.body = new MonitorRequestBody(this.dateTime, this.requestPath, this.type);
        }

        public Boolean send(){
            using( var content = new StringContent(this.body.ToJSON(), Encoding.UTF8, "application/json")){
                var res = client.PostAsync(requestUri, content).Result;
                
                res.EnsureSuccessStatusCode();
                return true;
            }
        }
    }
}

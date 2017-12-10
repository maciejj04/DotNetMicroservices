using System;

namespace ProxyService.Controllers
{
    public class MonitorRequestBody
    {
        public DateTime dateTime{get;set;}
        public string targetPath{get;set;}
        public Type type{get;set;}
        
        public MonitorRequestBody(DateTime now, string targetUrl, Type type)
        {
            this.dateTime = now;
            this.targetPath = targetUrl;
            this.type = type;
        }
    }
}
using Newtonsoft.Json;
using ProxyService.Controllers;

namespace ProxyService
{
    public static class JSONHelper
    {
        public static string ToJSON(this MonitorRequestBody obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
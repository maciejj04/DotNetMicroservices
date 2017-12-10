using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MonitoringService.Controllers
{
    [Route("api/[controller]")]
    public class MonitorController : Controller
    {
        private DBService db;
        public MonitorController(DBService db)
        {
            this.db = db;
        }

        [HttpGet]
        public Dictionary<string, AgregatedTransactionInfo> Get()
        {
            return db.transactions;
        }
        [HttpPost]
        [Route("handleRequest")]
        public IActionResult basicRequest([FromBody] Transaction transaction)
        {
            var headers = Request.Headers;
            if ( !headers.ContainsKey("TraceId")){
                return BadRequest();
            }
            db.AddTransaction(headers["traceId"], transaction);
            return Ok();
        }
        [HttpGet]
        [Route("transactionInfo/{id}")]

        public IActionResult getTransactionInfo(int id)
        {
            return Ok(db.getAgregatedTransactionInfo(id));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cqrs_webapi.CQRS;
using cqrs_webapi.ReadModel;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_webapi.Controllers
{
    [Route("api/[controller]")]
    public class MicroserviceController : Controller
    {
        ReadModelFacade readFacade;
        CommandBus bus;
        public MicroserviceController(CommandBus bus, ReadModelFacade readServicesFacade){
            this.readFacade = readServicesFacade;
            this.bus = bus;
        }

        // GET api/microservice
        [HttpGet]
        public IEnumerable<MicroserviceTemplate> Get()
        {
            return readFacade.getCreatableMicroserviceTemplates();
        }
        [HttpPost]
        public void CreateMicroservice([FromBody]CreateMicroserviceRequest body)
        {
            bus.send(new CreateMicroserviceTemplate(body.name, body.description, body.nativeLanguage, body.techStack));
        }
        [HttpPost]
        [Route("byname")]
        public MicroserviceTemplate getTemplate([FromBody]string name){
            return readFacade.getTemplateByName(name);
        }
    }
}

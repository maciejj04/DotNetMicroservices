using System.Collections.Generic;
using cqrs_webapi.CQRS;
using Microsoft.EntityFrameworkCore;

namespace cqrs_webapi{
    public class ReadDataBase
    {
        public List<MicroserviceTemplate> templatesRepository{get;set;}

        public ReadDataBase()
        {
            this.templatesRepository = new List<MicroserviceTemplate>();
            this.templatesRepository.Add(new MicroserviceTemplate(0,"queues-service","technica queues", "Java8", 
                new Dictionary<string,string>(){
                    {"SpringBoot","2.0"},
                    {"JRebel","0.14"}
                }
            ));
        }        
    }
}
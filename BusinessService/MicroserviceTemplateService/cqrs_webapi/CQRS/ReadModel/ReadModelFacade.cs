using System.Collections.Generic;
using cqrs_webapi.CQRS;

namespace cqrs_webapi.ReadModel{
    public interface IReadServiceFacade{
        List<MicroserviceTemplate> getCreatableMicroserviceTemplates();
        MicroserviceTemplate getTemplateByName(string name);
    }
    public class ReadModelFacade : IReadServiceFacade
    {
        ReadDataBase dataBase;
        public ReadModelFacade(ReadDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public List<MicroserviceTemplate> getCreatableMicroserviceTemplates()
        {
            return dataBase.templatesRepository;
        }
        public MicroserviceTemplate getTemplateByName(string name){
            return dataBase.templatesRepository.Find(e => e.name.Equals(name));
        }
    }
}
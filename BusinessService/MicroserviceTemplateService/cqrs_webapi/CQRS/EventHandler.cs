using System;
using cqrs_webapi.CQRS;

namespace cqrs_webapi{
    public interface IEventHandler{}
    public interface IEventHandler<T>: IEventHandler{
        void Handle(T eventy); // wydarzonko
    }
    public class MicroserviceEventHandler: 
                IEventHandler<CreateMicroserviceTemplateEvent>,
                IEventHandler<RenameMicroserviceTemplateEvent>,
                IEventHandler<DeleteMicroserviceTemplateEvent>
    {
        private ReadDataBase dataBase{get;set;}
        
        public MicroserviceEventHandler(ReadDataBase db){
            dataBase = db;
        }

        public void Handle(CreateMicroserviceTemplateEvent message){
            Random random = new Random();
            dataBase.templatesRepository.Add(
                    new MicroserviceTemplate(random.Next(), message.name, message.description, message.nativeLanguage,message.techStack)
            );
        }
        public void Handle(RenameMicroserviceTemplateEvent message){
            var template = dataBase.templatesRepository.Find(e => e.name.Equals(message.oldName));
            template.name = message.newName;
        }
        public void Handle(DeleteMicroserviceTemplateEvent message){
            dataBase.templatesRepository.RemoveAll(e=> e.name.Equals(message.name));
        }
    }
}
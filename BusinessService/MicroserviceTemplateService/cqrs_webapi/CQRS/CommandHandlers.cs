using System;
using cqrs_webapi.CQRS;

namespace cqrs_webapi{
    public interface ICommandHandler{}
    public interface ICommandHandler<T>: ICommandHandler{
        void Handle(T command);
    }
    class MicroserviceCommandHandler: 
                ICommandHandler<CreateMicroserviceTemplate>,
                ICommandHandler<RenameMicroserviceTemplate>,
                ICommandHandler<DeleteMicroserviceTemplate>
    {
        private WriteDataBase writeDataBase{get;set;}
        private EventBus eventBus;
        public MicroserviceCommandHandler(WriteDataBase db, EventBus eventBus){
            writeDataBase = db;
            this.eventBus = eventBus;
        }

        public void Handle(CreateMicroserviceTemplate message){
            Random random = new Random();
            writeDataBase.templatesRepository.Add(
                    new MicroserviceTemplate(random.Next(), message.name, message.description, message.nativeLanguage,message.techStack)
            );
            eventBus.send(new CreateMicroserviceTemplateEvent(message.name, message.description, message.nativeLanguage, message.techStack));
        }
        public void Handle(RenameMicroserviceTemplate message){
            var template = writeDataBase.templatesRepository.Find(e => e.name.Equals(message.oldName));
            template.name = message.newName;
            eventBus.send(new RenameMicroserviceTemplateEvent(message.oldName, message.newName));

        }
        public void Handle(DeleteMicroserviceTemplate message){
            writeDataBase.templatesRepository.RemoveAll(e=> e.name.Equals(message.name));
            eventBus.send(new DeleteMicroserviceTemplateEvent(message.name));
        }


    }
}
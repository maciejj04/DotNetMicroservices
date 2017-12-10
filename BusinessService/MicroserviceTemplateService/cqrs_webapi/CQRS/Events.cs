using System.Collections.Generic;

namespace cqrs_webapi{
    public class Event{}
    public class CreateMicroserviceTemplateEvent: Event{
        public string name;
        public string description;
        public string nativeLanguage;
        public Dictionary<string,string> techStack;
        public CreateMicroserviceTemplateEvent(string name, string description,string nativeLanguage, Dictionary<string,string> techStack)
        {
            this.description = description;
            this.techStack = techStack;
            this.nativeLanguage = nativeLanguage;
            this.name = name;
        }
    }

    public class RenameMicroserviceTemplateEvent: Event{
        public string oldName;
        public string newName;
        public RenameMicroserviceTemplateEvent(string oldName, string newName){
            this.oldName = oldName;
            this.newName = newName;
        }
    }
    public class DeleteMicroserviceTemplateEvent: Event{
        public string name;
        public DeleteMicroserviceTemplateEvent(string name)
        {
            this.name = name;
        }
    }
}
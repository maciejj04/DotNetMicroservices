using System.Collections.Generic;

namespace cqrs_webapi{
    public class Command{}

    public class CreateMicroserviceTemplate : Command {
        public string name;
        public string description;
        public string nativeLanguage;
        public Dictionary<string,string> techStack;
        public CreateMicroserviceTemplate(string name, string description,string nativeLanguage, Dictionary<string,string> techStack)
        {
            this.description = description;
            this.techStack = techStack;
            this.nativeLanguage = nativeLanguage;
            this.name = name;
        }
    }
    public class RenameMicroserviceTemplate{
        public string oldName;
        public string newName;
        public RenameMicroserviceTemplate(string oldName, string newName){
            this.oldName = oldName;
            this.newName = newName;
        }
    }
    public class DeleteMicroserviceTemplate : Command {
        public string name;
        public DeleteMicroserviceTemplate(string name)
        {
            this.name = name;
        }
    }



}
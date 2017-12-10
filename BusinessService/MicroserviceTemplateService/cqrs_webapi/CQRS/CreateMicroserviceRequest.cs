using System.Collections.Generic;

namespace cqrs_webapi.Controllers
{
    public class CreateMicroserviceRequest
    {
        public string name;
        public string description;
        public string nativeLanguage;
        public Dictionary<string,string> techStack;
            
        public CreateMicroserviceRequest(string name, string description, string nativeLanguage, Dictionary<string,string> techStack)
        {
            this.name = name;
            this.description = description;
            this.nativeLanguage = nativeLanguage;
            this.techStack = techStack;
        }

    }
}
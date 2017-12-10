using System.Collections.Generic;

namespace cqrs_webapi.CQRS
{
    public class MicroserviceTemplate
    {
        public MicroserviceTemplate(int id, string name, string description, string nativeLanguage, Dictionary<string,string> techStack)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.nativeLanguage = nativeLanguage;
            this.techStack = techStack;
        }

        public int id{get;set;}
        public string name{get;set;}
        public string description{get;set;}
        public string nativeLanguage{get;set;}
        public Dictionary<string,string> techStack{get;set;}
        
    }
}
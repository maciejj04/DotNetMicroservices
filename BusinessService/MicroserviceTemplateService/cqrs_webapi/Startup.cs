using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using cqrs_webapi.ReadModel;

namespace cqrs_webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var writeDataBase = new WriteDataBase();
            services.AddSingleton<WriteDataBase>(writeDataBase);
            var readDataBase = new ReadDataBase();
            services.AddSingleton<ReadDataBase>(readDataBase);
            var microserviceEventHandler = new MicroserviceEventHandler(readDataBase);
            services.AddSingleton<MicroserviceEventHandler>(microserviceEventHandler);

            //IEventHandler
            var eventHandlers = new Dictionary<Type, List<IEventHandler>>(){
                {typeof(CreateMicroserviceTemplateEvent), new List<IEventHandler>(){microserviceEventHandler}},
                {typeof(DeleteMicroserviceTemplateEvent), new List<IEventHandler>(){microserviceEventHandler}},
                {typeof(RenameMicroserviceTemplateEvent), new List<IEventHandler>(){microserviceEventHandler}}
            };
            services.AddSingleton<Dictionary<Type, List<IEventHandler>>>(z=>eventHandlers);
            services.AddSingleton<EventBus, EventBus>();

            var microserviceCommandHandler = new MicroserviceCommandHandler(
                writeDataBase,
                (EventBus)services.BuildServiceProvider().GetService(typeof(EventBus))
            );
            Dictionary<Type, ICommandHandler> handlers = new Dictionary<Type, ICommandHandler>(){
                {typeof(CreateMicroserviceTemplate), microserviceCommandHandler},
                {typeof(RenameMicroserviceTemplate), microserviceCommandHandler}, 
                {typeof(DeleteMicroserviceTemplate), microserviceCommandHandler} 
            };

            services.AddMvc();
            services.AddSingleton<ReadModelFacade, ReadModelFacade>(); 
            services.AddSingleton<CommandBus, CommandBus>();
            services.AddSingleton<Dictionary<Type, ICommandHandler>>(handlers);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

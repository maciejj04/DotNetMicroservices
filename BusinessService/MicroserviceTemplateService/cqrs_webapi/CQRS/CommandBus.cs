using System;
using System.Collections.Generic;

namespace cqrs_webapi{
    interface ICommandSender{
        void send<T>(T command) where T : Command;
    }

    public class CommandBus: ICommandSender{
        private Dictionary<Type, ICommandHandler> _routes;
        public CommandBus(Dictionary<Type, ICommandHandler> routes)
        {
            _routes = routes;
        }

        public void send<T>(T command) where T : Command{
            ICommandHandler handler;

            if ( _routes.TryGetValue(typeof(T), out handler)){
                ((ICommandHandler<T>)handler).Handle(command);
            }
        }
    }
}
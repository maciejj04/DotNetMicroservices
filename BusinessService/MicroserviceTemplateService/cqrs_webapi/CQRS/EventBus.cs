using System;
using System.Collections.Generic;

namespace cqrs_webapi{
    interface IEventSender{
        void send<T>(T command) where T : Event;
    }

    public class EventBus: IEventSender{
        private Dictionary<Type, List<IEventHandler>> eventHandlers;
        public EventBus(Dictionary<Type, List<IEventHandler>> eventHandlers)
        {
            this.eventHandlers = eventHandlers;
        }

        public void send<T>(T eventy) where T : Event{
            List<IEventHandler> handlers;

            if (eventHandlers.TryGetValue(typeof(T), out handlers)){
                foreach(var h in handlers){
                    ((IEventHandler<T>)h).Handle(eventy);
                }
            }
        }
    }
}
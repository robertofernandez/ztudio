using System.Collections;
using System.Collections.Generic;

namespace com.sodhium.ztudio.CustomEvents
{
    public class CustomEvent
    {
        public enum EventType
        {
            moveCamera,
            moveCharacter
        }
    
        public EventType eventType { get; private set; }

        public Dictionary<string, object> @params { get; private set; }

        public CustomEvent(EventType eventType, Dictionary<string, object> @params)
        {
            this.eventType = eventType;
            this.@params = @params;
        }
    }
}

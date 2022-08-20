using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.sodhium.ztudio.CustomEvents
{
    public class ScheduledEvent
    {
        public CustomEvent customEvent;
        public long time;

        public ScheduledEvent(CustomEvent customEvent, long time)
        {
            this.customEvent = customEvent;
            this.time = time;
        }
    }
}

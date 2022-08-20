using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.sodhium.ztudio.CustomEvents;
using com.sodhium.ztudio.LogicModel.Handlers;
using com.sodhium.ztudio.LogicModel.Models;
using com.sodhium.ztudio.Graphics;
using System;

namespace com.sodhium.ztudio.LogicModel
{
    /// <summary>
    /// Initializes the Game Events handlers 
    /// and distribute the events to 
    /// the correct handlers.
    /// </summary>
    public class MovieController
    {
        private static MovieController instance;
        public static MovieController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MovieController();
                }

                return instance;
            }
        }

        private Dictionary<CustomEvent.EventType, CustomEventHandler> handlersMap = new Dictionary<CustomEvent.EventType, CustomEventHandler>();

        //ViewManager reference must be set before any handler can handle game events.
        public ViewManager viewManager;
        //public GameMap gameMap;

        protected MovieController()
        {
            InstantiateHandlers();
        }

        private void InstantiateHandlers()
        {
            handlersMap.Add(CustomEvent.EventType.moveCamera, new MoveCameraHandler());
            handlersMap.Add(CustomEvent.EventType.moveCharacter, new MoveCharacterHandler());
        }

        public void ProcessCustomEvent(CustomEvent CustomEvent)
        {
            if (handlersMap.ContainsKey(CustomEvent.eventType))
            {
                handlersMap[CustomEvent.eventType].Execute(CustomEvent.@params);
            }
            else
            {
                Debug.LogError(string.Format("MovieController does not have a handler for this type of CustomEvent: {0}", CustomEvent.eventType));
            }
        }
    }
}

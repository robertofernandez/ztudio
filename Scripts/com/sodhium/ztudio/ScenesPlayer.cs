using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using com.sodiuhm.ztudio.CustomEvents;
using com.sodiuhm.ztudio.LogicModel;
using com.sodiuhm.ztudio.Translators;
using System;

namespace com.sodhium.ztudio
{
    public class ScenesPlayer : MonoBehaviour
    {
        private static ScenesPlayer instance;
        public static ScenesPlayer Instance
        {
            get
            {
                return instance;
            }
        }

        private float timer = 0;
        private float speed = 1;
        private int eventIndex = 0;
        private ScheduledEvent activeScheduledEvent = null;
        private VisualTest activeTest;
        List<ScheduledEvent> ScheduledEvents = new List<ScheduledEvent>();
        private bool running = false;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                if (instance != this)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        public void ExecuteScene(SceneDescriptor sceneDescriptor, float speed = 1)
        {
            Debug.Log("Running Scene " + sceneDescriptor.sceneName);
            SceneManager.LoadScene(sceneDescriptor.file);
            this.speed = speed;
            activeTest = sceneDescriptor;
            ScheduledEvents = GenericParametersTranslator.Instance.translate(sceneDescriptor.root);
            activeScheduledEvent = ScheduledEvents[eventIndex];
            running = true;
        }

        private void Update()
        {
            if(running) {
				RunSceneTick();
			}
        }

        private void RunSceneTick()
        {
            timer += Time.deltaTime;
            if (timer >= (activeScheduledEvent.time / (speed * 1000)))
            {
                RunCustomEvent(activeScheduledEvent.CustomEvent);
                if (eventIndex == ScheduledEvents.Count - 1)
                {
                    StopRunning();
                }
                else
                {
                    eventIndex++;
                    activeScheduledEvent = ScheduledEvents[eventIndex];
                }
            }
        }

        private void StopRunning()
        {
            running = false;
            eventIndex = 0;
            speed = 0;
            ScheduledEvents.Clear();
            timer = 0;
        }

        private void RunCustomEvent(CustomEvent CustomEvent)
        {
            MovieController.Instance.ProcessCustomEvent(CustomEvent);
        }
    }
}

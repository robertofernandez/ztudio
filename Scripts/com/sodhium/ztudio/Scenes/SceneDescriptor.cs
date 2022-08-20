using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

namespace com.sodhium.ztudio.Scenes
{
    public class SceneDescriptor
    {
        public string sceneName { private set;  get; }
        public string description { private set; get; }
		public string sceneFile { private set; get; }
        public XElement root;

        public SceneDescriptor(XElement root)
        {
            sceneName = root.Attribute("name").Value;
            description = root.Attribute("description").Value;
			sceneFile = root.Attribute("file").Value;
            this.root = root;
        }

        /// <summary>
        /// This method should instantiate CustomEvents based on the params of testParams
        /// </summary>
        public void Execute()
        {
            ScenesPlayer.Instance.ExecuteScene(this);
        }
    }
}

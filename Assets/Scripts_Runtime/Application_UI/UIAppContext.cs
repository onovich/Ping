using System.Collections.Generic;
using UnityEngine;
using Ping.UI;

namespace Ping {

    public class UIAppContext {

        // Canvas
        public Canvas canvas;
        public Transform hudFakeCanvas;

        // Event
        public UIEventCenter eventCenter;

        // Prefab
        public Dictionary<string, GameObject> prefabDict;

        // Repo
        public Dictionary<string, MonoBehaviour> openedUniqueDict;

        // Infra
        public TemplateInfraContext templateInfraContext;

        public UIAppContext() {
            eventCenter = new UIEventCenter();
            prefabDict = new Dictionary<string, GameObject>();
            openedUniqueDict = new Dictionary<string, MonoBehaviour>();
        }

        public void Asset_AddPrefab(string name, GameObject prefab) {
            prefabDict.Add(name, prefab);
        }

        // Panel_Unique
        public void UniquePanel_Add(string name, MonoBehaviour comp) {
            openedUniqueDict.Add(name, comp);
        }

        public void UniquePanel_Remove(string name) {
            openedUniqueDict.Remove(name);
        }

        public bool UniquePanel_TryGet(string name, out MonoBehaviour comp) {
            return openedUniqueDict.TryGetValue(name, out comp);
        }

        public T UniquePanel_Get<T>() where T : MonoBehaviour {
            string name = typeof(T).Name;
            bool has = openedUniqueDict.TryGetValue(name, out var comp);
            if (!has) {
                return null;
            }
            var panel = comp as T;
            return panel;
        }

    }

}
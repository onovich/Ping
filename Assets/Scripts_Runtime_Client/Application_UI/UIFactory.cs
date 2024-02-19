using UnityEngine;

namespace Ping.UI {

    public static class UIFactory {

        // UniquePanel
        public static T UniquePanel_Open<T>(UIAppContext ctx) where T : MonoBehaviour {
            var dict = ctx.prefabDict;
            string name = typeof(T).Name;
            var prefab = GetPrefab(ctx, name);
            var panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<T>();
            ctx.UniquePanel_Add(name, panel);
            return panel;
        }

        public static void UniquePanel_Close<T>(UIAppContext ctx) where T : MonoBehaviour {
            string name = typeof(T).Name;
            bool has = ctx.UniquePanel_TryGet(name, out var panel);
            if (!has) {
                PLog.LogWarning($"UIFactory.Close<{name}>: Panel not found");
                return;
            }
            ctx.UniquePanel_Remove(name);
            GameObject.Destroy(panel.gameObject);
        }

        static GameObject GetPrefab(UIAppContext ctx, string name) {
            bool has = ctx.prefabDict.TryGetValue(name, out var prefab);
            if (!has) {
                PLog.LogError($"UIFactory.GetPrefab<{name}>: UI Prefab not found");
                return null;
            }
            return prefab;
        }

    }

}
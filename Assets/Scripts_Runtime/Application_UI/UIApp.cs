using System.Threading.Tasks;
using Ping.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Ping {
    public static class UIApp {

        public static void Init(UIAppContext ctx) {

        }

        public static async Task LoadAssets(UIAppContext ctx) {
            var list = await Addressables.LoadAssetsAsync<GameObject>("UI", null).Task;
            foreach (var prefab in list) {
                ctx.Asset_AddPrefab(prefab.name, prefab);
            }
        }

        public static void LateTick(UIAppContext ctx, float dt) {

        }

        // Panel - Login
        public static void Login_Open(UIAppContext ctx) {
            PanelLoginDomain.Open(ctx);
        }

        public static void Login_Close(UIAppContext ctx) {
            PanelLoginDomain.Close(ctx);
        }

    }

}
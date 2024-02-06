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

        // Panel - Score
        public static void Score_Open(UIAppContext ctx) {
            PanelScoreDomain.Open(ctx);
        }

        public static void Score_Close(UIAppContext ctx) {
            PanelScoreDomain.Close(ctx);
        }

        public static void Score_SetPlayer1Score(UIAppContext ctx, int score) {
            PanelScoreDomain.SetPlayer1Score(ctx, score);
        }

        public static void Score_SetPlayer2Score(UIAppContext ctx, int score) {
            PanelScoreDomain.SetPlayer2Score(ctx, score);
        }

        public static void Score_SetGameTime(UIAppContext ctx, float time) {
            PanelScoreDomain.SetGameTime(ctx, time);
        }

    }

}
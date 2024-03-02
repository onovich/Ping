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

        public static void Login_ShowWaitingPanel(UIAppContext ctx) {
            PanelLoginDomain.ShowWaitingPanel(ctx);
        }

        public static void Login_HideWaitingPanel(UIAppContext ctx) {
            PanelLoginDomain.HideWaitingPanel(ctx);
        }

        public static void Login_ShowStartGameBtn(UIAppContext ctx) {
            PanelLoginDomain.ShowStartGameBtn(ctx);
        }

        public static void Login_HideStartGameBtn(UIAppContext ctx) {
            PanelLoginDomain.HideStartGameBtn(ctx);
        }

        public static void Login_SetRoomInfo(UIAppContext ctx, string info) {
            PanelLoginDomain.SetRoomInfo(ctx, info);
        }

        public static void Login_SetStartGameBtnInterectable(UIAppContext ctx, bool interactable) {
            PanelLoginDomain.SetStartGameBtnInterectable(ctx, interactable);
        }

        // Panel - Score
        public static void Score_Open(UIAppContext ctx) {
            PanelScoreDomain.Open(ctx);
        }

        public static void Score_Close(UIAppContext ctx) {
            PanelScoreDomain.Close(ctx);
        }

        public static void Score_SetPlayerScore(UIAppContext ctx, int score, int playerIndex) {
            PanelScoreDomain.SetPlayerScore(ctx, score, playerIndex);
        }

        public static void Score_SetGameTime(UIAppContext ctx, float time) {
            PanelScoreDomain.SetGameTime(ctx, time);
        }

    }

}
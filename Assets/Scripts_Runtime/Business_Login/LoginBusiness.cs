using Ping.Protocol;
using Ping.Requests;
using UnityEngine;

namespace Ping.Business.Login {

    public class LoginBusiness {

        public static void Enter(LoginBusinessContext ctx) {
            UIApp.Login_Open(ctx.uiAppContext);
        }

        public static void Tick(LoginBusinessContext ctx, float dt) {
            OnNetEvent(ctx, dt);
        }

        static void OnNetEvent(LoginBusinessContext ctx, float dt) {
            RequestInfra.Tick_Login(ctx.reqContext, dt);
        }

        public static void Exit(LoginBusinessContext ctx) {
            UIApp.Login_Close(ctx.uiAppContext);
        }

        public static void ExitLogin(LoginBusinessContext ctx) {
            Exit(ctx);
        }

        // On UI Event
        public static void OnUICancleWaitingClick(LoginBusinessContext ctx) {
            UIApp.Login_HideWaitingPanel(ctx.uiAppContext);
            ctx.evt.CancleWaiting();
        }

        public static async void OnUILoginClick(LoginBusinessContext ctx) {
            UIApp.Login_ShowWaitingPanel(ctx.uiAppContext);
            UIApp.Login_SetRoomInfo(ctx.uiAppContext, "Connecting To Server...");
            await RequestInfra.Connect_ToServer(ctx.reqContext);
        }

        // On Net Res
        public static void OnNetResConnect(LoginBusinessContext ctx, ConnectResMessage msg) {
            UIApp.Login_SetRoomInfo(ctx.uiAppContext, $"Server Connect Status: {msg.status} ");
        }

        public static void OnNetResConnectError(LoginBusinessContext ctx, string msg) {
            UIApp.Login_SetRoomInfo(ctx.uiAppContext, $"Server Connect Error: {msg} ");
        }

        public static void OnNetResLogin(LoginBusinessContext ctx, JoinRoomResMessage msg) {
            UIApp.Login_Close(ctx.uiAppContext);
        }

        public static void TearDown(LoginBusinessContext ctx) {
            ExitLogin(ctx);
        }

    }

}
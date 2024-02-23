using Ping.Protocol;
using Ping.Requests;
using UnityEngine;

namespace Ping.Business.Login {

    public class LoginBusiness {

        public static void Enter(LoginBusinessContext ctx) {
            UIApp.Login_Open(ctx.uiAppContext);
        }

        public static void Tick(LoginBusinessContext ctx, float dt) {
        }

        public static void Exit(LoginBusinessContext ctx) {
            UIApp.Login_Close(ctx.uiAppContext);
        }

        public static void ExitLogin(LoginBusinessContext ctx) {
            Exit(ctx);
        }

        public static void OnUICancleWaitingClick(LoginBusinessContext ctx) {
            UIApp.Login_ShowWaitingPanel(ctx.uiAppContext, false);
            ctx.evt.CancleWaiting();
        }

        public static void OnUILoginClick(LoginBusinessContext ctx, string userName) {
            UIApp.Login_ShowWaitingPanel(ctx.uiAppContext, true);
            RequestInfra.JoinRoom_SendReq(ctx.reqContext, userName);
        }

        public static void OnResLogin(LoginBusinessContext ctx, JoinRoomResMessage msg) {
        }

        public static void TearDown(LoginBusinessContext ctx) {
            ExitLogin(ctx);
        }

    }

}
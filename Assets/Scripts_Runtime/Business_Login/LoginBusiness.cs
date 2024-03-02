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

        // On UI Event
        public static void OnUICancleWaitingClick(LoginBusinessContext ctx) {
            UIApp.Login_HideWaitingPanel(ctx.uiAppContext);
            ctx.evt.CancleWaiting();
        }

        public static void OnUIGameStartClick(LoginBusinessContext ctx) {
            UIApp.Login_SetStartGameBtnInterectable(ctx.uiAppContext, false);
            RequestInfra.Send_GameStartReq(ctx.reqContext);
        }

        public static void OnUIExitGameClick(LoginBusinessContext ctx) {
            Exit(ctx);
        }

        public static async void OnUILoginClick(LoginBusinessContext ctx, string userName) {
            ctx.ownerName = userName;
            UIApp.Login_ShowWaitingPanel(ctx.uiAppContext);
            UIApp.Login_SetRoomInfo(ctx.uiAppContext, "Connecting To Server...");
            await RequestInfra.Connect_ToServer(ctx.reqContext);
        }

        // On Net Res
        public static void OnNetResConnect(LoginBusinessContext ctx, ConnectResMessage msg) {
            UIApp.Login_SetRoomInfo(ctx.uiAppContext, $"Server Connect Status: {msg.status} ");
            RequestInfra.Send_JoinRoomReq(ctx.reqContext, ctx.ownerName);
            PLog.Log("Send Join Room Req, Player Index = " + msg.playerIndex);
        }

        public static void OnNetResConnectError(LoginBusinessContext ctx, string msg) {
            UIApp.Login_SetRoomInfo(ctx.uiAppContext, $"Server Connect Error: {msg} ");
        }

        public static void OnNetResJoinRoom(LoginBusinessContext ctx, JoinRoomBroadMessage msg) {
            var userNames = msg.userNames;
            var ownerIndex = msg.ownerIndex;
            var status = msg.status;
            UIApp.Login_SetRoomInfo(ctx.uiAppContext, $"Join Status: {status}; OwnerID: {ownerIndex}; Player1 Name: {userNames[0]}; Player2 Name: {userNames[1]}");
            UIApp.Login_ShowStartGameBtn(ctx.uiAppContext);
            UIApp.Login_SetStartGameBtnInterectable(ctx.uiAppContext, true);
        }

        public static void OnNetResGameStart(LoginBusinessContext ctx, GameStartBroadMessage msg) {
            UIApp.Login_Close(ctx.uiAppContext);
            var evt = ctx.evt;
            evt.LoginDone(ctx.ownerName);
        }

        public static void TearDown(LoginBusinessContext ctx) {
            Exit(ctx);
        }

    }

}
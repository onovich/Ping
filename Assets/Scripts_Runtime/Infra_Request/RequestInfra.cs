using System;
using MortiseFrame.Abacus;
using MortiseFrame.Rill;
using Ping.Protocol;
using UnityEngine;

namespace Ping.Requests {

    public static class RequestInfra {

        //  Register
        public static void RegisterAllProtocol(RequestInfraContext ctx) {
            var client = ctx.ClientCore;
            client.Register(typeof(ConnectResMessage));
            client.Register(typeof(EntitiesSyncBroadMessage));
            client.Register(typeof(GameResultBroadMessage));
            client.Register(typeof(GameStartBroadMessage));
            client.Register(typeof(GameStartReqMessage));
            client.Register(typeof(JoinRoomBroadMessage));
            client.Register(typeof(JoinRoomReqMessage));
            client.Register(typeof(KeepAliveReqMessage));
            client.Register(typeof(KeepAliveResMessage));
            client.Register(typeof(LeaveRoomBroadMessage));
            client.Register(typeof(LeaveRoomReqMessage));
            client.Register(typeof(PaddleMoveReqMessage));
        }

        //  Send
        public static void Send(RequestInfraContext ctx, IMessage msg) {
            ctx.ClientCore.Send(msg);
        }

        //  Tick
        public static void Tick(RequestInfraContext ctx, float dt) {
            ctx.ClientCore.Tick(dt);
        }

        //  Connect
        public static void Connect(RequestInfraContext ctx) {
            var remoteIP = ctx.isTest ? RequestConst.REMOTE_IP_TEST : RequestConst.REMOTE_IP;
            var port = RequestConst.REMOTE_PORT;
            ctx.ClientCore.Connect(remoteIP, port);
            PLog.Log("Connect to " + remoteIP + ":" + port);
        }

        //  On  
        public static void On<T>(RequestInfraContext ctx, Action<IMessage> listener) where T : IMessage {
            ctx.ClientCore.On<T>(listener);
        }

        public static void OnError(RequestInfraContext ctx, Action<string> listener) {
            ctx.ClientCore.OnError(listener);
        }

        public static void OnConnected(RequestInfraContext ctx, Action listener) {
            ctx.ClientCore.OnConnect(listener);
        }

        public static void OnDisconnected(RequestInfraContext ctx, Action listener) {
            ctx.ClientCore.OnDisconnect(listener);
        }

        //  Off
        public static void Off<T>(RequestInfraContext ctx, Action<IMessage> listener) where T : IMessage {
            ctx.ClientCore.Off<T>(listener);
        }

        public static void OffError(RequestInfraContext ctx, Action<string> listener) {
            ctx.ClientCore.OffError(listener);
        }

        public static void OffConnected(RequestInfraContext ctx, Action listener) {
            ctx.ClientCore.OffConnect(listener);
        }

        public static void OffDisconnected(RequestInfraContext ctx, Action listener) {
            ctx.ClientCore.OffDisconnect(listener);
        }

        public static void Stop(RequestInfraContext ctx) {
            ctx.ClientCore.Stop();
        }

        // Send Req
        // - Login
        public static void SendLogin_JoinRoomReq(RequestInfraContext ctx, string token) {
            var msg = new JoinRoomReqMessage();
            msg.userName = token;
            ctx.ClientCore.Send(msg);
        }

        public static void SendLogin_GameStartReq(RequestInfraContext ctx) {
            var msg = new GameStartReqMessage();
            ctx.ClientCore.Send(msg);
        }

        // - Game
        public static void SendGame_PaddleMoveReq(RequestInfraContext ctx, Vector2 axis) {
            var msg = new PaddleMoveReqMessage();
            msg.moveAxis = axis.ToFVector2();
            ctx.ClientCore.Send(msg);
        }

    }

}
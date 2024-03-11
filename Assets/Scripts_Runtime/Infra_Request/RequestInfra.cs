using System.Threading.Tasks;
using MortiseFrame.Abacus;

namespace Ping.Requests {

    public static class RequestInfra {

        public static void Tick_Net(RequestInfraContext ctx, float dt) {
            var client = ctx.Client;
            if (client == null) {
                return;
            }
            if (!client.Poll(0, System.Net.Sockets.SelectMode.SelectRead)) {
                return;
            }
            byte[] data = new byte[4096];
            int count = client.Receive(data);
            if (count <= 0) {
                return;
            }

            // Login
            OnLogin_ConnectRes(ctx, data);
            OnLogin_JoinRoomRes(ctx, data);
            OnLogin_StartGameBroadRes(ctx, data);

            // Game
            OnGame_EntitiesSyncBroadRes(ctx, data);

        }

        // Connect
        public static async Task Connect_ToServer(RequestInfraContext ctx) {
            await RequestConnectDomain.ConnectToServerAsync(ctx);
        }

        // Send Req
        // - Login
        public static void SendLogin_JoinRoomReq(RequestInfraContext ctx, string token) {
            RequestJoinRoomDomain.Send_JoinRoomReq(ctx, token);
        }

        public static void SendLogin_GameStartReq(RequestInfraContext ctx) {
            RequestGameStartDomain.Send_GameStartReq(ctx);
        }

        // - Game
        public static void SendGame_PaddleMoveReq(RequestInfraContext ctx, FVector2 axis) {
            RequestPaddleMoveDomain.Send_PaddleMoveReq(ctx, axis);
        }

        // On Res
        // - Login
        public static void OnLogin_ConnectRes(RequestInfraContext ctx, byte[] data) {
            RequestConnectDomain.On_ConnectRes(ctx, data);
        }

        public static void OnLogin_JoinRoomRes(RequestInfraContext ctx, byte[] data) {
            RequestJoinRoomDomain.On_JoinRoomBroadRes(ctx, data);
        }

        public static void OnLogin_StartGameBroadRes(RequestInfraContext ctx, byte[] data) {
            RequestGameStartDomain.On_GameStartBroadRes(ctx, data);
        }

        // - Game
        public static void OnGame_EntitiesSyncBroadRes(RequestInfraContext ctx, byte[] data) {
            RequestEntitiesSyncDomain.On_EntitiesSyncBroadRes(ctx, data);
        }

    }

}